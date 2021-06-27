using KingResearch.Domain.Models;
using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Quaries
{
    public class EventHandlers : IRequestHandler<EventRequest, EventResponse>
    {
        private IBusinesRepository<Event> _businesRepository;
        public EventHandlers(IBusinesRepository<Event> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<EventResponse> Handle(EventRequest request, CancellationToken cancellationToken)
        {
            EventResponse response = new EventResponse();
            response.Events = _businesRepository.GetAll();
            return Task.FromResult(response);   
        }
    }
}
