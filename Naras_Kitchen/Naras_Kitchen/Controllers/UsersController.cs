using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.HttpsPolicy;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Naras_Kitchen.Services.Interfaces;
using Naras_Kitchen.Helpers;
using Microsoft.AspNetCore.Authorization;
using Naras_Kitchen.ViewModels;
using Naras_Kitchen.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Naras_Kitchen.Controllers
{
    //Authorize(Roles = "Administrator")]
     [Authorize(Policy = "RequireAdministratorRole")]

    public class UsersController : Controller
    {
        
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly RecipeDbContext Context;
        public UsersController(IUserService userService, UserManager<IdentityUser> UserManager, RecipeDbContext Context, RoleManager<IdentityRole> roleManager)
        {
            this.userService = userService;
            this.UserManager = UserManager;
            this.Context = Context;
            this.roleManager = roleManager;
        }



        public async Task<IActionResult> Seed() 
        {
            var userId = "f59fd244-2837-45b6-8220-de6d02854a0e";
            var user = userService.GetById(userId);
            var role = new IdentityRole();
            role.Name = "Administrator";
          await roleManager.CreateAsync(role);
            //UserManager.AddToRoleAsync(user, role.Name);




            if (await UserManager.IsInRoleAsync(user, "Admin"))
            {
                await UserManager.RemoveFromRoleAsync(user, "Admin");
                await UserManager.AddToRoleAsync(user, role.Name);
                return RedirectToAction("Overview");

            }
            else
            {
                await UserManager.RemoveFromRoleAsync(user, "User");
                await UserManager.AddToRoleAsync(user, role.Name);
                return RedirectToAction("Overview");


            }
            
        }

        public  async Task<IActionResult> Overview()
        {

            var dbUsers = userService.GetAll();
            //var viewModels =  dbUsers.Select(x => x.ToViewModel()).ToList();
            var viewModels = new List<UserOverviewViewModel>();
            foreach (var user in dbUsers) 
            {
                var viewModel = new UserOverviewViewModel();
                viewModel.Id = user.Id;
                viewModel.Username = user.UserName;
                viewModel.Password = user.PasswordHash;
                if (await UserManager.IsInRoleAsync(user, "Admin"))
                    {
                    viewModel.isAdmin = true;
                }
                else 
                {
                    viewModel.isAdmin = false;
                }
                viewModels.Add(viewModel);
            }

            
            
            return View(viewModels);
        }

      
        public IActionResult Delete(string id) 
        {
            var user = userService.GetById(id);
            userService.Delete(user);
            return RedirectToAction("Overview");
        }

      
        public async Task<IActionResult> EditUserRole(string id)
        {
            var user = userService.GetById(id);
            
            if (await UserManager.IsInRoleAsync(user, "Admin"))
            {
                await UserManager.RemoveFromRoleAsync(user, "Admin");
                await UserManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Overview");

            }
            else
            {
                await UserManager.RemoveFromRoleAsync(user, "User");
                await UserManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("Overview");


            }
        }

     
        public  IActionResult Edit(string id)
        {
            var user = userService.GetById(id);


            var viewModel =  user.ToEditUserViewModel();

            return View(viewModel);
        }
       
        [HttpPost]
        public  IActionResult Edit(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = editUserViewModel.FromEditUserViewModel();
                userService.Edit(user);
                return RedirectToAction("Overview");
            }


            return RedirectToAction("Edit");
        }




    }
}
