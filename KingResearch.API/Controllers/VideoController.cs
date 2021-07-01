using KingResearch.Application.Features.Videos.Command;
using KingResearch.Application.Features.Videos.Delete;
using KingResearch.Application.Features.Videos.Quaries;
using KingResearch.Application.Features.Videos.Update;
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
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new VideoRequest()));
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateVideoRequest video)
        {
            return Ok(await _mediator.Send(video));
        }


        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateVideoRequest video)
        {
            return Ok(await _mediator.Send(video));
        }


        [HttpDelete]
        public async Task<IActionResult> PostAsync(int videoId)
        {
            return Ok(await _mediator.Send(new DeleteVideoRequest() { VideoId = videoId}));
        }
    }
}
