using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Naras_Kitchen.Data;
using Microsoft.EntityFrameworkCore;
using Naras_Kitchen.Repositories.Interfaces;

namespace Naras_Kitchen.Repositories
{
    public class UserRepsitory : IUserRepository
    {
        private readonly RecipeDbContext Context;
        public UserRepsitory(RecipeDbContext Context)
        {
            this.Context = Context;
        }



        public List<IdentityUser> GetAll()
        {
            var users = Context.Users.ToList();
            return users;
        }

        public IdentityUser GetById(string id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(IdentityUser user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
        }
        public void Delete(IdentityUser user)
        {
            Context.Users.Remove(user);
            Context.SaveChanges();
        }
    }
}
