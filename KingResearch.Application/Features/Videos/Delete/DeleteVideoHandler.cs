using KingResearch.Application.Exception;
using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Videos.Delete
{
    public class DeleteVideoHandler : IRequestHandler<DeleteVideoRequest, DeleteVideoResponse>
    {
        private IBusinesRepository<Domain.Models.Service> _businesRepository;
        public DeleteVideoHandler(IBusinesRepository<Domain.Models.Service> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<DeleteVideoResponse> Handle(DeleteVideoRequest request, CancellationToken cancellationToken)
        {
            if (request?.VideoId == 0)
            {
                throw new ValidationException("Video Id request");
            }
            _businesRepository.Remove(_businesRepository.GetById(request.VideoId));

            return Task.FromResult(new DeleteVideoResponse { Success = "Video deleted successfully." });

        }
    }
}
