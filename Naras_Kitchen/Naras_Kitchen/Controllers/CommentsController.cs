using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Naras_Kitchen.ViewModels;
using Naras_Kitchen.Helpers;
using Naras_Kitchen.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Naras_Kitchen.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService Service;
        private readonly UserManager<IdentityUser> UserManager;
        public CommentsController(ICommentService Service, UserManager<IdentityUser> UserManager )
        {
            this.Service = Service;
            this.UserManager = UserManager;
        }
        public IActionResult Add(string commentText, int recipeId)
        {
            if (!String.IsNullOrEmpty(commentText)) 
            {
                var userName = UserManager.GetUserName(User);
                var userId = UserManager.GetUserId(User);
                Service.Add(commentText, recipeId, userId, userName);
                
            }
            return RedirectToAction("Detailss", "Home", new { id = recipeId });
        }

    
    }
}
