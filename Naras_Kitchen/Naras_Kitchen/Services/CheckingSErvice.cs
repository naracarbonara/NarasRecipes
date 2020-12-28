using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using Naras_Kitchen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services
{
    public class CheckingSErvice:ICheckingService
    {
        private readonly ICheckingRepository CheckingRepo;
        public CheckingSErvice(ICheckingRepository CheckingRepo)
        {
            this.CheckingRepo = CheckingRepo;
        }

        public void Add(int ingredientId,  string userId) 
        {
            var checking = new Checking();
            checking.IngredientId = ingredientId;
            checking.UserId = userId;
            CheckingRepo.Add(checking);
        }

        public void Remove(int ingredientId, string userId)
        {
            var checking = CheckingRepo.GetChecking(ingredientId, userId);
            CheckingRepo.Remove(checking);
        }
    }
}
