using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services.Interfaces
{
   public interface ICheckingService
    {
       void Add(int ingredientId, string userId);
        void Remove(int ingredientId, string userId);
    }
}
