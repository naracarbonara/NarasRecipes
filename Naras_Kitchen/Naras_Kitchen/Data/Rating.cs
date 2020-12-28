using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}
