 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Naras_Kitchen.Data;
using Naras_Kitchen.Services.Interfaces;

namespace Naras_Kitchen.Controllers
{
    public class CheckingController : Controller
    {
        private readonly ICheckingService Service;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly RecipeDbContext Context;

        public CheckingController(ICheckingService Service, UserManager<IdentityUser> UserManager, RecipeDbContext Context)
        {
            this.Service = Service;
            this.UserManager = UserManager;
            this.Context = Context;
        }
        public IActionResult AddChecking(int ingredientId)
        {
            var userId = UserManager.GetUserId(User);
            Service.Add(ingredientId, userId);
            var ingredient = Context.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
            var id = ingredient.RecipeId;
            return RedirectToAction("CheckIngredients", "Home", new { recipeId = id });
        }

        public IActionResult RemoveChecking(int ingredientId)
        {
            var userId = UserManager.GetUserId(User);
            Service.Remove(ingredientId, userId);
            var ingredient = Context.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
            var id = ingredient.RecipeId;
            return RedirectToAction("CheckIngredients", "Home", new { recipeId = id });
        }
    }
}
