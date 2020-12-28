using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Naras_Kitchen.Repositories.Interfaces;
using Naras_Kitchen.Services.Interfaces;

namespace Naras_Kitchen.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepo;
        public UserService(IUserRepository UserRepo)
        {
            this.UserRepo = UserRepo;
        }

        public List<IdentityUser> GetAll()
        {
            return UserRepo.GetAll();
        }

        public IdentityUser GetById(string id)
        {
            return UserRepo.GetById(id);
        }

        public void Edit(IdentityUser user)
        {

            var dbUser = UserRepo.GetById(user.Id);
            dbUser.UserName = user.UserName;
            dbUser.SecurityStamp = user.SecurityStamp;
            
           

            UserRepo.Update(dbUser);
        }

        public void Delete(IdentityUser user) 
        {
            UserRepo.Delete(user);
        }
    }
}
