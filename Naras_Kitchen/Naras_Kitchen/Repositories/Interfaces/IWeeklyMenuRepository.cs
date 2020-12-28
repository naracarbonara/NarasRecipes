using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Repositories.Interfaces
{
  public  interface IWeeklyMenuRepository
    {
        void Add(WeeklyMenu menu);
        List<WeeklyMenu> GetByUser(string userId);

        void Remove(WeeklyMenu menu);
        WeeklyMenu GetMenu(string userId, int recipeId, string day);
    }
}
