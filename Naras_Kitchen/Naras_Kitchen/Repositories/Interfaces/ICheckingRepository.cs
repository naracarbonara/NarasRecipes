using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Repositories.Interfaces
{
   public interface ICheckingRepository
    {
        void Add(Checking checking);
        void Remove(Checking checking);

        Checking GetChecking(int ingredientId, string userId);
    }
}
