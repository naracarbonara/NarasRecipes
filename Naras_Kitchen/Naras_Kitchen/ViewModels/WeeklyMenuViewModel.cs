using Microsoft.AspNetCore.Identity;
using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.ViewModels
{
    public class WeeklyMenuViewModel
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public string Day { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}
