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

namespace KingResearch.Application.Features.Events.Command
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, CreateEventResponse>
    {
        private IBusinesRepository<Domain.Models.Event> _businesRepository;
        public CreateEventHandler(IBusinesRepository<Domain.Models.Event> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<CreateEventResponse> Handle(CreateEventRequest request, CancellationToken cancellationToken)
        {
            CreateEventValidator validator = new CreateEventValidator();
            ValidationResult validationResult = validator.Validate(request);
            if (validationResult?.Errors?.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }
            _businesRepository.Insert(request.ToEvent());
            return Task.FromResult(new CreateEventResponse { Success = "Record inserted successfully." });
        }
    }
}
