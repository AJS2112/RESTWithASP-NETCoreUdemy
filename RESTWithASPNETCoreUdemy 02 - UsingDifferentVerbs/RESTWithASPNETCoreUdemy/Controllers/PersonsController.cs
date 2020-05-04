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

    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private IPersonBusiness _personBusiness;
        
        public PersonsController(ILogger<PersonsController> logger, IPersonBusiness personBusiness)
        { 
            _personBusiness = personBusiness;
             _logger = logger;
        }


        /// <response code="200">Returns the newly created item</response>
        [HttpGet]
        [ProducesResponseType( typeof(List<PersonVO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        [HttpPut]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return NoContent();
            return new ObjectResult(updatedPerson);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
