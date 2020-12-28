using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using Naras_Kitchen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services
{
    public class WeeklyMenuService:IWeeklyMenuService
    {
        private readonly IWeeklyMenuRepository MenuRepo;
        private readonly IRecipesRepository RecipeRepo;
        private readonly ICheckingRepository CheckingRepo;
        public WeeklyMenuService(IWeeklyMenuRepository MenuRepo, IRecipesRepository RecipeRepo)
        {
            this.MenuRepo = MenuRepo;
            this.RecipeRepo = RecipeRepo;
          
        }

        public  void Add(string userId, string day, int recipeId)
        {
            var recipe = RecipeRepo.GetById(recipeId);
              var Menu = new WeeklyMenu();
 
            Menu.Day = day;
            Menu.Recipe = recipe;
            //Menu.RecipeId = recipeId;
            Menu.Day = day;
            Menu.UserId = userId;

            MenuRepo.Add(Menu);
            recipe.WeeklyMenus.Add(Menu);
            //RecipeRepo.Edit(recipe);
        }

        public List<WeeklyMenu> GetByUser(string userId) 
        {
            var WeeklyMenus = MenuRepo.GetByUser(userId);
            return WeeklyMenus;
        }

        public void  Remove(string userId, int recipeId, string day)
        {
            var menu = MenuRepo.GetMenu(userId, recipeId, day);
            MenuRepo.Remove(menu);

      
        }


    }
}
