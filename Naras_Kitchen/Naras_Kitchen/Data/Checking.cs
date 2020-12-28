using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Data
{
    public class Checking
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public Ingredient Ingredient  { get; set; }
        public int IngredientId { get; set; }
    }
}
