using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using Tapioca.HATEOAS;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Authorize("Bearer")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<PersonVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonVO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpGet("FindByName")]
        [ProducesResponseType(typeof(List<PersonVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult GetByName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            return Ok(_personBusiness.FindByName(firstName, lastName));
        }
        
        [HttpGet("GetByNameWithPagedSearch/{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType(typeof(List<PersonVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult GetByNameWithPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(_personBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(PersonVO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        [ProducesResponseType(typeof(PersonVO), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return new ObjectResult(_personBusiness.Update(person));
        }

        // PUT api/values/5
        [HttpPatch]
        [ProducesResponseType(typeof(PersonVO), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Patch([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return new OkObjectResult(_personBusiness.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
