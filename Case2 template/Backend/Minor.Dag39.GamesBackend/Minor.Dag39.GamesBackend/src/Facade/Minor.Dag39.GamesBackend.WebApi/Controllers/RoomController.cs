using System;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Minor.Dag39.GamesBackend.Services;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.Outgoing;

namespace Minor.Dag39.GamesBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly RoomService _service;

        public RoomController(RoomService service)
        {
            _service = service;
        }

        // POST api/values
        [HttpPost]        
        [SwaggerOperation("Post")]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.BadRequest)]
        public IActionResult CreateGame([FromBody]Room room)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest(room);
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerOperation("Update")]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.BadRequest)]
        public IActionResult EndGame([FromBody]Room room)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest(room);
        }
        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}
