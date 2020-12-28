using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Naras_Kitchen.Data;

namespace Naras_Kitchen.ViewModels
{
    public class RecipeViewModel
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
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Type { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public List<Rating> Ratings { get; set; }
        public double AvgRating { get; set; }

        //public double avgRating;


        ////public RecipeViewModel(double avg)
        ////{
        ////    avgRating = avg;
        ////}

        //public double AvgRating
        //{

        //    get => Ratings.Sum(x => x.Value) / Ratings.Count;
        //    set => avgRating = value;
        //}


    }
}
