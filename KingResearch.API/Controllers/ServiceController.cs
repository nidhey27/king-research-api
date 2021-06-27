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
        public IActionResult Get()
        {
            return Ok(_mediator.Send(new ServiceRequest()));
        }


        [HttpPost]
        public IActionResult Post(CreateServiceRequest model)
        {
            return Ok(_mediator.Send(model));
        }

        [HttpPut]

        public IActionResult Update(UpdateServiceRequest request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpDelete]

        public IActionResult Update(int ServiceId)
        {
            return Ok(_mediator.Send(new DeleteServiceRequest { ServiceId = ServiceId}));
        }
    }
}
