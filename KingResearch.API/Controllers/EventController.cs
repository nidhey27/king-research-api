using KingResearch.Application.Features.Events.Command;
using KingResearch.Application.Features.Events.Delete;
using KingResearch.Application.Features.Events.Update;
using KingResearch.Application.Features.Quaries;
using KingResearch.Application.Features.Videos.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingResearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mediator.Send(new EventRequest()));
        }


        [HttpPost]
        public IActionResult Post(CreateEventRequest model)
        {
            return Ok(_mediator.Send(model));
        }

        [HttpPut]
        public IActionResult Put(UpdateEventRequest model)
        {
            return Ok(_mediator.Send(model));
        }

        [HttpDelete]
        public IActionResult Delete(int eventId)
        {
            return Ok(_mediator.Send(new DeleteEventRequest { EventId = eventId }));
        }
    }
}
