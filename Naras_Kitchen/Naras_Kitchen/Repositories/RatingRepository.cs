using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Repositories
{
    public class RatingRepository:IRatingRepository
    {
        private readonly RecipeDbContext Context;
        public RatingRepository(RecipeDbContext Context)
        {
            this.Context = Context;
        }

        public void Add(Rating rating) 
        {
            Context.Ratings.Add(rating);
            Context.SaveChanges();
        }

        public void Update(Rating rating)
        {
            Context.Ratings.Update(rating);
            Context.SaveChanges();
        }
        public void Remove(Rating rating)
        {
            Context.Ratings.Remove(rating);
            Context.SaveChanges();
        }

        public Rating GetById(int id) 
        {
            return Context.Ratings.FirstOrDefault(x => x.Id == id);
        }

        public List<Rating> GetAllRatings(int id) 
        {
            return Context.Ratings.Where(x => x.RecipeId == id).ToList();
        }

        public Rating GetByUserAndRecipe(string userId, int recipeId) 
        {
            return Context.Ratings.FirstOrDefault(x => x.UserId == userId && x.RecipeId == recipeId);
        }
    }
}
