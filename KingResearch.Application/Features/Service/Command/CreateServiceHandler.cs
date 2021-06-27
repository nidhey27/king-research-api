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

namespace KingResearch.Application.Features.Service.Command
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceRequest, CreateServiceResponse>
    {
        private IBusinesRepository<Domain.Models.Service> _businesRepository;
        public CreateServiceHandler(IBusinesRepository<Domain.Models.Service> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<CreateServiceResponse> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
        {
            CreateServiceValidator validator = new CreateServiceValidator();
            ValidationResult validationResult = validator.Validate(request);
            if (validationResult?.Errors?.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }
            _businesRepository.Insert(request.ToService());
            return Task.FromResult(new CreateServiceResponse { Success = "Record inserted successfully." });
        }
    }
}
