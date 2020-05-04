using RESTWithASPNETCoreUdemy.Models;
using RESTWithASPNETCoreUdemy.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTWithASPNETCoreUdemy.Repository.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySQLContext _context;
        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(p => p.Login.Equals(login));
        }
    }
}
