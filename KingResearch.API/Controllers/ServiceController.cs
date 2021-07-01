using KingResearch.Application.Features.Service.Command;
using KingResearch.Application.Features.Service.Delete;
using KingResearch.Application.Features.Service.Quaries;
using KingResearch.Application.Features.Service.Update;
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
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new ServiceRequest()));
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateServiceRequest model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAsync(UpdateServiceRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]

        public async Task<IActionResult> UpdateAsync(int ServiceId)
        {
            return Ok(await _mediator.Send(new DeleteServiceRequest { ServiceId = ServiceId}));
        }
    }
}
