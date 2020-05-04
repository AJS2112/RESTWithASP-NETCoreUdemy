using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTWithASPNETCoreUdemy.Data.VO;
using RESTWithASPNETCoreUdemy.Models;
using RESTWithASPNETCoreUdemy.Services;
using RESTWithASPNETCoreUdemy.Services.Business;
using Tapioca.HATEOAS;

namespace RESTWithASPNETCoreUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private ILoginBusiness _loginBusiness;
        
        public LoginController(ILogger<LoginController> logger, ILoginBusiness loginBusiness)
        { 
            _loginBusiness = loginBusiness;
             _logger = logger;
        }


        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(HyperMediaFilter))]

        public object Post([FromBody] User user)
        {
            if (user == null) return BadRequest();
            return new ObjectResult(_loginBusiness.FindByLogin(user));
        }

    }
}
