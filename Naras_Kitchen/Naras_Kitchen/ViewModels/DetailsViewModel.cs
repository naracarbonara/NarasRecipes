using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Naras_Kitchen.Data;

namespace Naras_Kitchen.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Directions { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Type { get; set; }

        [Required]
        public string UserId { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<WeeklyMenu> WeeklyMenus { get; set; }
        public double AvgRating { get; set; }
    }
}
