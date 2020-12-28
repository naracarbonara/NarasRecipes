using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services.Interfaces
{
    public interface IRatingService
    {
        void Add(int value, string userId, int recipeId);
        void Remove(int id);
        void Edit(int value, string userId, int recipeId);
    }
}
