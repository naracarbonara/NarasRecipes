using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Naras_Kitchen.Data;

namespace Naras_Kitchen.Services.Interfaces
{
    public interface IRecipesService
    {
        Recipe GetById(int id);
        void Create(string userId, Recipe recipe);
        List<Recipe> GetAll();
        void Delete(Recipe post);
        void Edit(Recipe post);
        List<Recipe> GetByTitle(string title);
        List<Recipe> GetByCountry(string country);

        void AddIngredient(int recipeId, string ingredient, string quantity);
        void DeleteIngredient(Ingredient ingredient);

        Ingredient GetIngredientById(int id);
        List<Recipe> GetByType(string type);
    }
}
