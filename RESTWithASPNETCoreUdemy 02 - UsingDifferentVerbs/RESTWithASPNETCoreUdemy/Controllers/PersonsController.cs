using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTWithASPNETCoreUdemy.Models;
using RESTWithASPNETCoreUdemy.Services;
using RESTWithASPNETCoreUdemy.Services.Business;

namespace RESTWithASPNETCoreUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private IPersonBusiness _personBusiness;
        
        public PersonsController(ILogger<PersonsController> logger, IPersonBusiness personBusiness)
        { 
            _personBusiness = personBusiness;
             _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return NoContent();
            return new ObjectResult(updatedPerson);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
