using KingResearch.Application.Features.DMat.Command;
using KingResearch.Application.Features.DMat.Delete;
using KingResearch.Application.Features.DMat.Quaries;
using KingResearch.Application.Features.DMat.Update;
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
    public class DMatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DMatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mediator.Send(new DMatRequest()));
        }


        [HttpPost]
        public IActionResult Post(CreateDMatRequest model)
        {
            return Ok(_mediator.Send(model));
        }

        [HttpPut]

        public IActionResult Update(UpdateDMatRequest request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpDelete]

        public IActionResult Update(int dmatId)
        {
            return Ok(_mediator.Send(new DeleteDMatRequest { DMatId = dmatId }));
        }
    }
}
