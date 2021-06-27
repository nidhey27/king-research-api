
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

namespace KingResearch.Application.Features.Service.Update
{
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceRequest, UpdateServiceResponse>
    {
        private IBusinesRepository<Domain.Models.Service> _businesRepository;
        public UpdateServiceHandler(IBusinesRepository<Domain.Models.Service> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<UpdateServiceResponse> Handle(UpdateServiceRequest request, CancellationToken cancellationToken)
        {
            UpdateServiceValidator validator = new UpdateServiceValidator();
            ValidationResult validationResult = validator.Validate(request);
            if (validationResult?.Errors?.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Domain.Models.Service service =  _businesRepository.GetById(request.ServiceId);

            if (service == null)
            {
                throw new ValidationException("No records found for the service id =" + request.ServiceId);       
            }

            service.ServiceDescription = request.ServiceDescription;
            service.ServiceName = request.ServiceName;
            service.UpdatedBy = request.UpdatedBy;            
            service.UpdatedOn = DateTime.Now;


            _businesRepository.Update(service);
            return Task.FromResult(new UpdateServiceResponse { Success = "Record updated successfully." });
        }
    }
}
