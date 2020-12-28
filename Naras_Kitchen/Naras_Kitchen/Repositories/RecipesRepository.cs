using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;

namespace Naras_Kitchen.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly RecipeDbContext Context;
        public RecipesRepository(RecipeDbContext Context)
        {
            this.Context = Context;
        }
        public Recipe GetById(int id)
        {
            //return Context.Recipes.FirstOrDefault(x => x.Id == id)

                  return Context.Recipes
                .Include(x => x.Ingredients)
                .Include(x=>x.Comments)   
                .ThenInclude(x=>x.User)
               .Include(x=>x.Ratings)
               .Include(x=>x.WeeklyMenus)
                 .FirstOrDefault(x => x.Id == id);
           
        }

        public List<Recipe> GetAll()
        {
            return Context.Recipes
                .Include(x => x.Ingredients)
                .ToList();
        }
        public void Create(Recipe recipe)
        {
            Context.Recipes.Add(recipe);
            Context.SaveChanges();
        }

        public void Delete(Recipe recipe)
        {
            Context.Recipes.Remove(recipe);
            Context.SaveChanges();
        }

        public void Edit(Recipe recipe)
        {
            Context.Recipes.Update(recipe);
            Context.SaveChanges();
        }

        public List<Recipe> GetByTitle(string title)
        {
            var recipes = Context.Recipes.AsQueryable();
            if (!String.IsNullOrEmpty(title))
            {
                recipes = recipes
                    //.Include(x=>x.Ratings)
                    //.Include(x=>x.AvgRating)
                    .Include(x=>x.Ingredients)
                    .Include(x=>x.WeeklyMenus)
                    .Where(x => x.Title.Contains(title));
            }
            return recipes.ToList();
        }

        public List<Recipe> GetByCountry(string country)
        {
            var recipes = Context.Recipes.AsQueryable();

            if (!String.IsNullOrEmpty(country))
            {
                recipes = recipes.Where(x => x.Country.Contains(country));
            }

            return recipes.ToList();
        }

        public List<Recipe> GetByType(string type)
        {
            var recipes = Context.Recipes.AsQueryable();

            if (!String.IsNullOrEmpty(type))
            {
                recipes = recipes.Where(x => x.Type.Contains(type));
            }

            return recipes.ToList();
        }




        public void AddIngredient(Ingredient ingredient) 
        {
            //proverka dali go ima
            Context.Ingredients.Add(ingredient);
            Context.SaveChanges();
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            
            Context.Ingredients.Remove(ingredient);
            Context.SaveChanges();
        }

        public Ingredient GetIngredientById(int id) 
        {
            return Context.Ingredients.FirstOrDefault(x => x.Id == id);
        }
    }
}
