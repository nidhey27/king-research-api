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
        public IActionResult Get()
        {
            return Ok(_mediator.Send(new VideoRequest()));
        }


        [HttpPost]
        public IActionResult Post(CreateVideoRequest video)
        {
            return Ok(_mediator.Send(video));
        }


        [HttpPut]
        public IActionResult Put(UpdateVideoRequest video)
        {
            return Ok(_mediator.Send(video));
        }


        [HttpDelete]
        public IActionResult Post(int videoId)
        {
            return Ok(_mediator.Send(new DeleteVideoRequest() { VideoId = videoId}));
        }
    }
}
