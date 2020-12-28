using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using Naras_Kitchen.Services.Interfaces;

namespace Naras_Kitchen.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository RecipeRepo;
        public RecipesService(IRecipesRepository RecipeRepo)
        {
            this.RecipeRepo = RecipeRepo;
        }
        public Recipe GetById(int id)
        {
            return RecipeRepo.GetById(id);
        }
        public void Create(string userId, Recipe recipe)
        {
            recipe.UserId = userId;
            recipe.DateCreated = DateTime.Now;
            RecipeRepo.Create(recipe);
        }

        public List<Recipe> GetAll()
        {
            return RecipeRepo.GetAll();
        }


        public void Delete(Recipe recipe)
        {
            RecipeRepo.Delete(recipe);
        }
        public void Edit(Recipe recipe)
        {

            RecipeRepo.Edit(recipe);
        }

        public List<Recipe> GetByTitle(string title)
        {
            return RecipeRepo.GetByTitle(title);
        }

        public List<Recipe> GetByCountry(string country)
        {
            return RecipeRepo.GetByCountry(country);
        }

        public List<Recipe> GetByType(string type) 
        {
            return RecipeRepo.GetByType(type);
        }

        public void AddIngredient(int recipeId, string ingredient, string quantity) 
        {
            var recipe = RecipeRepo.GetById(recipeId);
            var ingredients = recipe.Ingredients;
            var ingred = new Ingredient();
            ingred.Name = ingredient;
            ingred.Quantity = quantity;
            ingred.RecipeId = recipeId;
            ingredients.Add(ingred);
            RecipeRepo.Edit(recipe);
            //RecipeRepo.AddIngredient(ingred);
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
          RecipeRepo.DeleteIngredient(ingredient);
        }

        public Ingredient GetIngredientById(int id) 
        {
          return  RecipeRepo.GetIngredientById(id);
        }

        
    }
}
