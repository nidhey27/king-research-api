using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Command
{
    public class CreateDMatValidator : AbstractValidator<CreateDMatRequest>
    {
        public CreateDMatValidator()
        {
            RuleFor(req => req).NotNull();
            RuleFor(x =>x.DmatName).NotNull().NotEmpty().WithMessage("DMat name required");
            RuleFor(x => x.DmatLink).NotNull().NotEmpty().WithMessage("DMat link is required");        
        }
    }
}
