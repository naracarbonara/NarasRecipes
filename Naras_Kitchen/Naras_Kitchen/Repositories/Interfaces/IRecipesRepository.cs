using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Naras_Kitchen.Data;

namespace Naras_Kitchen.Repositories.Interfaces
{
    public interface IRecipesRepository
    {
        Recipe GetById(int id);

        void Create(Recipe recipe);

        List<Recipe> GetAll();
        void Delete(Recipe recipe);
        void Edit(Recipe recipe);
        List<Recipe> GetByTitle(string title);
        List<Recipe> GetByCountry(string country);
        List<Recipe> GetByType(string type);
        void AddIngredient(Ingredient ingredient);
        void DeleteIngredient(Ingredient ingredient);

        Ingredient GetIngredientById(int id);
      
    }
}
