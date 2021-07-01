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
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new EventRequest()));
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateEventRequest model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateEventRequest model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int eventId)
        {
            return Ok(await _mediator.Send(new DeleteEventRequest { EventId = eventId }));
        }
    }
}
