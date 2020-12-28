using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Repositories
{
    public class CheckingRepository:ICheckingRepository
    {
        private readonly RecipeDbContext Context;
        public CheckingRepository(RecipeDbContext Context)
        {
            this.Context = Context;
        }

        public void Add(Checking checking) 
        {
            Context.Checkings.Add(checking);
            Context.SaveChanges();

        }
        public void Remove(Checking checking)
        {
            Context.Checkings.Remove(checking);
            Context.SaveChanges();

        }


        public Checking GetChecking(int ingredientId, string userId) 
        {
            return Context.Checkings.FirstOrDefault(x => x.IngredientId == ingredientId && x.UserId == userId);
        }
    }
}
