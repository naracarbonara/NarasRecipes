using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Naras_Kitchen.Data;

namespace Naras_Kitchen.ViewModels
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }

        
        public int RecipeId { get; set; }

    }
}
