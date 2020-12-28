using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Naras_Kitchen.Services.Interfaces;

namespace Naras_Kitchen.Controllers
{
    public class RatingsController : Controller
    {
        private readonly IRatingService RatingService;
        private readonly UserManager<IdentityUser> Usermanager;
        public RatingsController(IRatingService RatingService, UserManager<IdentityUser> Usermanager)
        {
            this.RatingService = RatingService;
            this.Usermanager = Usermanager;
        }
        public IActionResult Add(int recipeId, int value)
        {
            if (recipeId!=0) 
            {
                var userId = Usermanager.GetUserId(User);
                RatingService.Add(value, userId, recipeId);
            }
            return RedirectToAction("Detailss", "Home", new { id = recipeId });
        }


        public IActionResult Edit(int recipeId, int value) 
        {
            var userId = Usermanager.GetUserId(User);
            RatingService.Edit(value, userId, recipeId);
            return RedirectToAction("Detailss", "Home", new { id = recipeId });
        }
    }
}
