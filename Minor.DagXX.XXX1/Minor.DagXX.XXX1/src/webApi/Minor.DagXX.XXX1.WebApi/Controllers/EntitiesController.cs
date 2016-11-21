using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Minor.DagXX.XXX1.Entities.Entities;
using Minor.DagXX.XXX1.WebApi.Errors;
using Minor.DagXX.XXX1.DAL.DAL;

namespace Minor.DagXX.XXX1.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EntitiesController : Controller
    {
        private IRepository<Entity, int> _repo;

        public EntitiesController(IRepository<Entity, int> repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        [SwaggerOperation("GetAll")]
        public IEnumerable<Entity> Get()
        {
            return _repo.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetByID")]
        [ProducesResponseType(typeof(Entity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.Find(id));

            }
            catch (Exception)
            {
                var error = new ErrorMessage("US002.1a", "Geen Slak met deze ID");
                return NotFound(error);
            }
        }

        // POST api/values
        [HttpPost]
        [SwaggerOperation("Insert")]
        public void Post([FromBody]Entity value)
        {
            _repo.Insert(value);
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerOperation("Update")]
        public void Put([FromBody]Entity value)
        {
            _repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerOperation("Delete")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
