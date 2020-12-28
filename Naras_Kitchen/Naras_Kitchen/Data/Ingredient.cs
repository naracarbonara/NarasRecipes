using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Data
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
       
        public int RecipeId { get; set; }

        public List<Checking> Checkings { get; set; }
    }
}
