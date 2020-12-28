using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Naras_Kitchen.Data;


namespace Naras_Kitchen.Data
{

    public class RecipeDbContext : IdentityDbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public DbSet<WeeklyMenu> WeeklyMenus { get; set; }
        public DbSet<Day> Days { get; set; }

        public DbSet<Checking> Checkings { get; set; }

    }
}
