using System;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Minor.Dag39.GamesBackend.Services;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.Outgoing;
using Minor.Dag39.GamesBackend.Incoming.Commands;
using Minor.Dag39.GamesBackend.WebApi.Errors;
using Microsoft.EntityFrameworkCore;

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
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult CreateGame([FromBody]CreateRoomCommand createCommand)
        {
            if (!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate Invalide");
                return BadRequest(error);
            }
                try
                {
                    var room = _service.StartGame(createCommand);
                    return Ok(room);
                }
                catch (Exception)
                {
                    var error = new ErrorMessage(ErrorTypes.Unknown,
                        $"Onbekende fout met volgende Command: RoomName:{createCommand.RoomName}, CommandId:{createCommand.CommandId}, TimeStamp:{createCommand.Timestamp}");
                    return BadRequest(error);
                }


        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerOperation("Update")]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult EndGame([FromBody]EndGameCommand endCommand)
        {
            if (ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate Invalide");
                return BadRequest(error);
            }
            try
            {
                var room = _service.EndGame(endCommand);
                return Ok(room);
            }
            catch (DbUpdateException)
            {
                var error = new ErrorMessage(ErrorTypes.NotFound,
                        $"Fout met updaten game met volgende Command: RoomName:{endCommand.RoomName}, CommandId:{endCommand.CommandId}, TimeStamp:{endCommand.Timestamp}");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown,
                        $"Onbekende fout met volgende Command: RoomName:{endCommand.RoomName}, CommandId:{endCommand.CommandId}, TimeStamp:{endCommand.Timestamp}");
                return BadRequest(error);
            }
        }
        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}
