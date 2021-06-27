using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Service.Command
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceRequest>
    {
        public CreateServiceValidator()
        {
            RuleFor(req => req).NotNull();
            RuleFor(x =>x. ServiceName).NotNull().NotEmpty().WithMessage("Service name required");
            RuleFor(x => x.ServiceDescription).NotNull().NotEmpty().WithMessage("Service description is required");  
        }
    }
}
