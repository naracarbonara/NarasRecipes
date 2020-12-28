using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Repositories
{
    public class DayRepository:IDayRepository
    {
        private readonly RecipeDbContext Context;

        public DayRepository(RecipeDbContext Context)
        {
            this.Context = Context;
        }

        public void Add(Day day)
        {
            Context.Days.Add(day);
            Context.SaveChanges();
        }
    }
}
