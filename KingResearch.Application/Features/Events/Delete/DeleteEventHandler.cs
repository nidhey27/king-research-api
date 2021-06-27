using KingResearch.Application.Exception;
using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Events.Delete
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, DeleteEventResponse>
    {
        private IBusinesRepository<Domain.Models.Event> _businesRepository;
        public DeleteEventHandler(IBusinesRepository<Domain.Models.Event> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<DeleteEventResponse> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
        {
            if (request?.EventId == 0)
            {
                throw new ValidationException("Event Id required");
            }
            _businesRepository.Remove(_businesRepository.GetById(request.EventId));

            return Task.FromResult(new DeleteEventResponse { Success = "Event deleted successfully." });

        }
    }
}
