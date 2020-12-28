using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Naras_Kitchen.Repositories
{

  
    public class WeeklyMenuRepository:IWeeklyMenuRepository
    {
      private readonly RecipeDbContext Context;
      private readonly UserManager<IdentityUser> UserManager;
     

        public WeeklyMenuRepository(RecipeDbContext Context, UserManager<IdentityUser> UserManager)
        {
            this.Context = Context;
            this.UserManager = UserManager;
        }


        public void Add(WeeklyMenu menu) 
        {
            Context.WeeklyMenus.Add(menu);
            Context.SaveChanges();
        }

        public void Remove(WeeklyMenu menu)
        {
            var userId = menu.UserId;
            Context.WeeklyMenus.Remove(menu);
            var recipe = menu.Recipe;
            var Ingredients = recipe.Ingredients;
           
            foreach (var ingredient in Ingredients) 
            {
                var checking = Context.Checkings.FirstOrDefault(x => x.IngredientId == ingredient.Id && x.UserId==userId);
                if (checking != null) 
                {
                    Context.Checkings.Remove(checking);
                }
            
            }
            Context.SaveChanges();
        }
        public List<WeeklyMenu> GetByUser(string userId) 
        {
            var weeklyMenus = Context.WeeklyMenus.AsQueryable();

            weeklyMenus = weeklyMenus
                   //.Include(x=>x.Ratings)
                   //.Include(x=>x.AvgRating)
                   .Include(x => x.Recipe)
                   .ThenInclude(x=>x.Ingredients)
                   .Where(x => x.UserId == userId);
            return weeklyMenus.ToList();

        }

        public WeeklyMenu GetMenu(string userId, int recipeId, string day) 
        {
            return Context.WeeklyMenus
                .Include(x=>x.Recipe)
                
                .FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId && x.Day == day);
        }
    }
}
