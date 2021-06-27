using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Service.Update
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceRequest>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.ServiceDescription).NotNull().NotEmpty().WithMessage("Service Description is required");
            RuleFor(x=>x.ServiceName).NotNull().NotNull().NotEmpty().WithMessage("Service Name is required");
            RuleFor(x => x.ServiceId).NotNull().NotEmpty().WithMessage("Service Id is required");
        }
    }
}
