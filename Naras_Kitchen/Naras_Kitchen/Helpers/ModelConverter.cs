using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Identity;
using Naras_Kitchen.Data;
using Naras_Kitchen.ViewModels;





namespace Naras_Kitchen.Helpers
{
    public static class ModelConverter
    {
        private static readonly UserManager<IdentityUser> userManager;



        //public ModelConverter(UserManager<IdentityUser> userManager)
        //{
        //   this.userManager = userManager;

        //}
        public static RecipeViewModel ToViewModel(this Recipe recipe)
        {

            return new RecipeViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Directions = recipe.Directions,
                Ingredients = recipe.Ingredients,
                ImageUrl = recipe.ImageUrl,

                Type = recipe.Type,
                Country = recipe.Country,
                DateCreated = recipe.DateCreated,
                UserId = recipe.UserId,
                Ratings=recipe.Ratings,
                AvgRating=recipe.AvgRating
            };
        }

        public static Recipe FromViewModel(this RecipeViewModel recipeViewModel)
        {
            return new Recipe
            {
                Id = recipeViewModel.Id,
                Title = recipeViewModel.Title,
                Description = recipeViewModel.Description,
                Directions = recipeViewModel.Directions,
                Ingredients = recipeViewModel.Ingredients,
                ImageUrl = recipeViewModel.ImageUrl,

                Type = recipeViewModel.Type,
                Country = recipeViewModel.Country,
                DateCreated = recipeViewModel.DateCreated,
                UserId = recipeViewModel.UserId,
                AvgRating = recipeViewModel.AvgRating
            };
        }

        public static Recipe FromCreateViewModel(this CreateRecipeViewModel createRecipeVieModel)
        {
            return new Recipe
            {
                Id = createRecipeVieModel.Id,
                Title = createRecipeVieModel.Title,
                Directions = createRecipeVieModel.Directions,
                Description = createRecipeVieModel.Description,
                ImageUrl = createRecipeVieModel.ImageUrl,
                Ingredients = createRecipeVieModel.Ingredients,
                Country = createRecipeVieModel.Country,
                Type = createRecipeVieModel.Type,
            };
        }
        public static CreateRecipeViewModel ToCreateViewModel(this Recipe recipe)
        {
            return new CreateRecipeViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Directions = recipe.Directions,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = new List<Ingredient>(),
                Country = recipe.Country,
                Type = recipe.Type
                
                 


            };
        }
        public static DetailsViewModel ToDetailsViewModel(this Recipe recipe)
        {
            return new DetailsViewModel
            {
                Id = recipe.Id,
                ImageUrl = recipe.ImageUrl,
                Title = recipe.Title,
                Country = recipe.Country,
                Type = recipe.Type,
                Description = recipe.Description,
                Directions = recipe.Directions,
                Ingredients = recipe.Ingredients,
                UserId = recipe.UserId,
                Comments=recipe.Comments,
                Ratings=recipe.Ratings,
                AvgRating=recipe.AvgRating,
                 WeeklyMenus = recipe.WeeklyMenus
            };
        }

        public static Recipe FromDetailsViewModel(this DetailsViewModel detailsViewModel)
        {
            return new Recipe
            {
                Id = detailsViewModel.Id,
                ImageUrl = detailsViewModel.ImageUrl,
                Title = detailsViewModel.Title,
                Country = detailsViewModel.Country,
                Type = detailsViewModel.Type,
                Description = detailsViewModel.Description,
                Directions = detailsViewModel.Directions,
                Ingredients = detailsViewModel.Ingredients,
                UserId = detailsViewModel.UserId,
                Comments = detailsViewModel.Comments,
                Ratings = detailsViewModel.Ratings,
                AvgRating = detailsViewModel.AvgRating,
                WeeklyMenus= detailsViewModel.WeeklyMenus

            };
        }

        public static EditViewModel ToEditViewModel(this Recipe recipe)
        {
            return new EditViewModel
            {
                ImageUrl = recipe.ImageUrl,
                Title = recipe.Title,
                Country = recipe.Country,
                Type = recipe.Type,
                Description = recipe.Description,
                Directions = recipe.Directions,
                //Ingredients = recipe.Ingredients,
                UserId = recipe.UserId,
                Id = recipe.Id
               
            };
        }

        public static Recipe FromEditViewModel(this EditViewModel editViewModel)
        {
            return new Recipe
            {
                Id = editViewModel.Id,
                ImageUrl = editViewModel.ImageUrl,
                Title = editViewModel.Title,
                Country = editViewModel.Country,
                Type = editViewModel.Type,
                Description = editViewModel.Description,
                Directions = editViewModel.Directions,

                UserId = editViewModel.UserId
               
            };
        }

        public static  UserOverviewViewModel ToViewModel(this IdentityUser user)
        {
            var userOverviewViewModel = new UserOverviewViewModel();
            //return new UserOverviewViewModel
            //{
            //    Id = user.Id,
            //    Username = user.UserName,
            //    Password = user.PasswordHash,


            //}

            userOverviewViewModel.Id = user.Id;
            userOverviewViewModel.Username = user.UserName;
            userOverviewViewModel.Password = user.PasswordHash;
           
            return userOverviewViewModel;

        }

        public static EditUserViewModel ToEditUserViewModel(this IdentityUser user)
        {
            var model = new EditUserViewModel();


            model.Id = user.Id;
            model.UserName = user.UserName;

            return model;
        }


        public static IdentityUser FromEditUserViewModel(this EditUserViewModel viewModel)
        {
            //var user = new IdentityUser();

            return new IdentityUser
            {
                Id = viewModel.Id,
                UserName = viewModel.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };
          
            //return user;
        }


        public static Ingredient FromIngredientViewModel(this IngredientViewModel viewModel)
        {
            return new Ingredient
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Quantity = viewModel.Quantity,
                RecipeId = viewModel.RecipeId,


            };
        }


        public static RecipeWeeklyMenuViewModel toWeeklyMenuViewModel(this Recipe recipe) 
        {

            return new RecipeWeeklyMenuViewModel
            {
                Id = recipe.Id,
                ImageUrl = recipe.ImageUrl,
                Title = recipe.Title,
                Country = recipe.Country,
                Type = recipe.Type,
                Description = recipe.Description,
                Directions = recipe.Directions,
                Ingredients = recipe.Ingredients,
                UserId = recipe.UserId,
              
               
                WeeklyMenus = recipe.WeeklyMenus


            };
        }


        public static WeeklyMenuViewModel toWeeklyViewModel(this WeeklyMenu menu) 
        {
            return new WeeklyMenuViewModel
            {
                Id = menu.Id,
                Recipe = menu.Recipe,
                RecipeId = menu.RecipeId,
                UserId = menu.UserId,
                Day = menu.Day,
                User=menu.User
              

            };
        }





    }
}
