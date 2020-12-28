using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services.Interfaces
{
    public interface IWeeklyMenuService
    {
       void Add(string userId, string day, int recipeId);
        List<WeeklyMenu> GetByUser(string userId);

        void Remove(string userId, int recipeId, string day);
    }
}
