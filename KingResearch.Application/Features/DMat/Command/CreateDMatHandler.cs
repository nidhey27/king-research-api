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

namespace KingResearch.Application.Features.DMat.Command
{
    public class CreateDMatHandler : IRequestHandler<CreateDMatRequest, CreateDMatResponse>
    {
        private IBusinesRepository<Domain.Models.Dmat> _businesRepository;
        public CreateDMatHandler(IBusinesRepository<Domain.Models.Dmat> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<CreateDMatResponse> Handle(CreateDMatRequest request, CancellationToken cancellationToken)
        {
                CreateDMatValidator validator = new CreateDMatValidator();
                ValidationResult validationResult = validator.Validate(request);
                if (validationResult?.Errors?.Count > 0)
                {
                    throw new ValidationException(validationResult.Errors);                    
                }
                _businesRepository.Insert(request.ToDmat());
                return Task.FromResult(new CreateDMatResponse { Success = "Record inserted successfully." });
        }
    }
}
