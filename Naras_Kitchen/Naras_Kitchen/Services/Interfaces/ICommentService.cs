using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services.Interfaces
{
   public interface ICommentService
    {
        void Add(string commentText, int recipeId, string userId, string userName);

    }
}
