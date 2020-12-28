using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Naras_Kitchen.Models;
using Naras_Kitchen.Services.Interfaces;
using Naras_Kitchen.Helpers;
using Naras_Kitchen.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Naras_Kitchen.Data;

namespace Naras_Kitchen.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRecipesService Service;
        private readonly IWeeklyMenuService MenuService;
        private readonly UserManager<IdentityUser> UserManager;
        public HomeController(IRecipesService Service, UserManager<IdentityUser> UserManager, IWeeklyMenuService MenuService)
        {
            this.Service = Service;
            this.UserManager = UserManager;
            this.MenuService = MenuService;
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Worldwide()
        {
            return View();
        }

        public IActionResult Home(string searchWord)
        {
            var dbRecipes = Service.GetByTitle(searchWord);
            var viewModels = dbRecipes.Select(x => x.ToViewModel()).ToList();
            return View(viewModels);
        }
        public IActionResult Overview(string title)
        {
            var dbRecipes = Service.GetByTitle(title);
            var viewModels = dbRecipes.Select(x => x.ToViewModel()).ToList();
            return View(viewModels);
        }

        public IActionResult OverviewCountryRelated(string country)
        {
            var dbRecipes = Service.GetByCountry(country);
            var viewModels = dbRecipes.Select(x => x.ToViewModel()).ToList();
            return View(viewModels);
        }

        public IActionResult OverviewTypeRelated(string type)
        {
            var dbRecipes = Service.GetByType(type);
            var viewModels = dbRecipes.Select(x => x.ToViewModel()).ToList();
            return View(viewModels);
        }

        public IActionResult Detailss(int id)
        {
            var recipe = Service.GetById(id);
            var viewModel = recipe.ToDetailsViewModel();
            return View(viewModel);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddIngredientItem([Bind("Ingredients")] Recipe recipe) 
        //{
        //    recipe.Ingredients.Add
        //}

        [Authorize]
        public IActionResult Create()
        {

            var createViewModel = new CreateRecipeViewModel();
            return View(createViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateRecipeViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.GetUserId(User);
                var recipe = createViewModel.FromCreateViewModel();
                Service.Create(user, recipe);

                return RedirectToAction("Detailss", "Home", new { id = recipe.Id });

              
            }
            return RedirectToAction("Home");

        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var recipe = Service.GetById(id);
            Service.Delete(recipe);
            return RedirectToAction("Overview");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var recipe = Service.GetById(id);
            var viewModel = recipe.ToEditViewModel();
            return View(viewModel);

        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditViewModel editViewModel)
        {

            if (ModelState.IsValid)
            {
                var recipe = editViewModel.FromEditViewModel();

                Service.Edit(recipe);
                return RedirectToAction("Overview");
            }


            return RedirectToAction("Edit");
        }

        public IActionResult CreateIngredient(int recipeId, string ingredient, string quantity) 
        {

            if (!String.IsNullOrEmpty(ingredient) && !String.IsNullOrEmpty(quantity)) 
            {
                Service.AddIngredient(recipeId, ingredient, quantity);
                //return RedirectToAction("Detailss");
            }
            return RedirectToAction("Detailss", "Home", new { id = recipeId });
        }

        public IActionResult DeleteIngredient(int id) 
        {
            var ingredient = Service.GetIngredientById(id);
           
           Service.DeleteIngredient(ingredient);

            return RedirectToAction("Detailss", "Home", new { id = ingredient.RecipeId });
        }


        public IActionResult CreateWeeklyMenu(int recipeId) 
        {
            var recipe = Service.GetById(recipeId);
           //var detailsViewModel = recipe.ToDetailsViewModel();
            var weeklyMenuViewModel = recipe.toWeeklyMenuViewModel();
            return View(weeklyMenuViewModel);
        }


      

        public IActionResult CreateMenu(string day, int recipeId )
        {
          var recipe = Service.GetById(recipeId);
            //var recipeTitle = recipe.Title;
            var userId = UserManager.GetUserId(User);
          
               MenuService.Add(userId, day, recipeId);
               //return RedirectToAction("Detailss");
            
            return RedirectToAction("Detailss", "Home", new { id = recipeId });
        }


        public IActionResult GetWeeklyMenu() 
        {
            var userId = UserManager.GetUserId(User);
            var dbMeewklyMneus = MenuService.GetByUser(userId);
            var viewModels = dbMeewklyMneus.Select(x => x.toWeeklyViewModel()).ToList();
            return View(viewModels);
        }

        public IActionResult RemoveFromWeeklyMenu(int recipeId, string day) 
        {
            var recipe = Service.GetById(recipeId);
            var userId = UserManager.GetUserId(User);
            MenuService.Remove(userId, recipeId, day);
            return RedirectToAction("GetWeeklyMenu");
        }

        public IActionResult CheckIngredients(int recipeId) 
        {
            var recipe = Service.GetById(recipeId);
            var viewModel = recipe.ToDetailsViewModel();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
