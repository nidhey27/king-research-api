using FluentValidation.Results;
using KingResearch.Application.Exception;
using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Events.Update
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventRequest, UpdateEventResponse>
    {
        private IBusinesRepository<Domain.Models.Event> _businesRepository;
        public UpdateEventHandler(IBusinesRepository<Domain.Models.Event> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<UpdateEventResponse> Handle(UpdateEventRequest request, CancellationToken cancellationToken)
        {
            UpdateEventValidator validator = new UpdateEventValidator();
            ValidationResult validationResult = validator.Validate(request);
            if (validationResult?.Errors?.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Domain.Models.Event eventData = _businesRepository.GetById(request.EventId);

            if (eventData == null)
            {
                throw new ValidationException("No records found for the event id =" + request.EventId);
            }

            eventData.EventContent = request.EventContent;
            eventData.EventDateTime = request.EventDateTime;
            eventData.EventDescription = request.EventDescription;
            eventData.EventName = request.EventName;
            eventData.EventVideoLink = request.EventVideoLink;
            eventData.UpdateBy = request.UpdateBy;
            eventData.UpdateOn = DateTime.Now;


            _businesRepository.Update(eventData);
            return Task.FromResult(new UpdateEventResponse { Success = "Record updated successfully." });
        }
    }
}
