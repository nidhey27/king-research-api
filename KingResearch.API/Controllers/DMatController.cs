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
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new DMatRequest()));
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateDMatRequest model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAsync(UpdateDMatRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]

        public async Task<IActionResult> UpdateAsync(int dmatId)
        {
            return Ok(await _mediator.Send(new DeleteDMatRequest { DMatId = dmatId }));
        }
    }
}
