using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using Naras_Kitchen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services
{
    public class RatingService:IRatingService
    {
        private readonly IRatingRepository RatingRepo;
        private readonly IRecipesRepository RecipeRepository;
        public RatingService(IRatingRepository RatingRepo, IRecipesRepository RecipeRepository)
        {
            this.RatingRepo = RatingRepo;
            this.RecipeRepository = RecipeRepository;
        }

        public void Add(int value, string userId, int recipeId) 
        {
            var recipe = RecipeRepository.GetById(recipeId);
            var rating = new Rating();
            rating.Value = value;
            rating.UserId = userId;
            rating.RecipeId = recipeId;
            RatingRepo.Add(rating);
            var ratings = RatingRepo.GetAllRatings(recipeId);
            var sum = 0.0;
            foreach (var rat in ratings) 
            {
                sum = sum + rat.Value;
            }
            var avg = sum / ratings.Count;
            recipe.AvgRating = avg;
            RecipeRepository.Edit(recipe);
        }


        public void Edit(int value,string userId, int  recipeId) 
        {
            var rating = RatingRepo.GetByUserAndRecipe(userId, recipeId);
            rating.Value = value;
            RatingRepo.Update(rating);
        }

        public void Remove(int id) 
        {
            var rating = RatingRepo.GetById(id);
            RatingRepo.Remove(rating);
        }
    }
}
