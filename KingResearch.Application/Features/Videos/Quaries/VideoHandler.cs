using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Videos.Quaries
{
    public class VideoHandler : IRequestHandler<VideoRequest, VideoResponse>
    {
        private IBusinesRepository<Domain.Models.Video> _businesRepository;
        public VideoHandler(IBusinesRepository<Domain.Models.Video> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<VideoResponse> Handle(VideoRequest request, CancellationToken cancellationToken)
        {
            VideoResponse response = new VideoResponse();
            response.Videos = _businesRepository.GetAll();
            return Task.FromResult(response);
        }
    }
}
