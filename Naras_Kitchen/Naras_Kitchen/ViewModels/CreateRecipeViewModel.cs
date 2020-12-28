using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Naras_Kitchen.Data;

namespace Naras_Kitchen.ViewModels
{
    public class CreateRecipeViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Directions { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
   
        [Required]
        public string Country { get; set; }
        [Required]
        public string Type { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<Ingredient> Ingredients { get; set; }

    }
}
