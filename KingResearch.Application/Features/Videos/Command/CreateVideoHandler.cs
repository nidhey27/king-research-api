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

namespace KingResearch.Application.Features.Videos.Command
{
    public class CreateVideoHandler : IRequestHandler<CreateVideoRequest, CreateVideoResponse>
    {
        private IBusinesRepository<Domain.Models.Video> _businesRepository;
        public CreateVideoHandler(IBusinesRepository<Domain.Models.Video> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<CreateVideoResponse> Handle(CreateVideoRequest request, CancellationToken cancellationToken)
        {
                CreateVideoValidator validator = new CreateVideoValidator();
                ValidationResult validationResult = validator.Validate(request);
                if (validationResult?.Errors?.Count > 0)
                {
                    throw new ValidationException(validationResult.Errors);                    
                }
                _businesRepository.Insert(request.ToVideo());
                return Task.FromResult(new CreateVideoResponse { Success = "Record inserted successfully." });
        }
    }
}
