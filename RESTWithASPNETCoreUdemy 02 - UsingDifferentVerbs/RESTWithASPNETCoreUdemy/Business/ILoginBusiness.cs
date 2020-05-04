using RESTWithASPNETCoreUdemy.Data.VO;
using RESTWithASPNETCoreUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTWithASPNETCoreUdemy.Services.Business
{
    public interface ILoginBusiness
    {
        Object FindByLogin (User user);
    }
}
