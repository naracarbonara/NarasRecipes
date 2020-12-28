using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Naras_Kitchen.Data
{
    public class Recipe

    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Directions { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        //public string Ingredients { get; set; }

        public string Country { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Rating> Ratings { get; set; }
        public double AvgRating { get; set; }
  
        public List<WeeklyMenu> WeeklyMenus { get; set; }
    }
}
