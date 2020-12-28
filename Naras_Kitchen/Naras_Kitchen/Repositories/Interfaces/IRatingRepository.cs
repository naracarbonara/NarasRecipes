using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Repositories.Interfaces
{
   public interface IRatingRepository
    {
        void Add(Rating rating);

        void Remove(Rating rating);

        Rating GetById(int id);
        List<Rating> GetAllRatings(int id);

        void Update(Rating rating);

        Rating GetByUserAndRecipe(string userId, int recipeId);
    }
}
