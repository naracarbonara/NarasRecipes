using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.ViewModels
{
    public class UserOverviewViewModel

    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool isAdmin { get; set; }
        //public List<WeeklyMenu> WeeklyMenus { get; set; }
    }
}
