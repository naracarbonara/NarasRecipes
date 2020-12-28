using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Naras_Kitchen.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IdentityUser GetById(string id);
        List<IdentityUser> GetAll();

        void Update(IdentityUser user);

        void Delete(IdentityUser user);
    }
}
