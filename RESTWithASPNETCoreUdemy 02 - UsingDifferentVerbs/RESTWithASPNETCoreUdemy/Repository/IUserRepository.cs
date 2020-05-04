using RESTWithASPNETCoreUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTWithASPNETCoreUdemy.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
