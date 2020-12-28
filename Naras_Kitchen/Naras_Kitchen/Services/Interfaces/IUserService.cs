using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Naras_Kitchen.Services.Interfaces
{
    public interface IUserService
    {
        List<IdentityUser> GetAll();
        IdentityUser GetById(string id);

        void Edit(IdentityUser user);

        void Delete(IdentityUser user);
    }
}
