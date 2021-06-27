using FluentValidation;
using FluentValidation.Results;
using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Update
{
    public class UpdateDMatHandler : IRequestHandler<UpdateDMatRequest, UpdateDMatResponse>
    {
        private IBusinesRepository<Domain.Models.Dmat> _businesRepository;
        public UpdateDMatHandler(IBusinesRepository<Domain.Models.Dmat> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<UpdateDMatResponse> Handle(UpdateDMatRequest request, CancellationToken cancellationToken)
        {
            UpdateDMatValidator validator = new UpdateDMatValidator();
            ValidationResult validationResult = validator.Validate(request);
            if (validationResult?.Errors?.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Domain.Models.Dmat dmat =  _businesRepository.GetById(request.DMatId);

            if (dmat == null)
            {
                throw new ValidationException("No records found for the video id =" + request.DMatId);       
            }

            dmat.UpdateBy = request.UpdateBy;
            dmat.UpdatedOn = DateTime.Now;
            dmat.DmatName = request.DmatName;
            dmat.DmatLink = request.DmatLink;
            dmat.UpdatedOn = DateTime.Now;

            _businesRepository.Update(dmat);
            return Task.FromResult(new UpdateDMatResponse { Success = "Record updated successfully." });
        }
    }
}
