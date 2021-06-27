using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Update
{
    public class UpdateDMatValidator : AbstractValidator<UpdateDMatRequest>
    {
        public UpdateDMatValidator()
        {
            RuleFor(req => req).NotNull();
            RuleFor(x => x.DmatName).NotNull().NotEmpty().WithMessage("DMAT name is required");
            RuleFor(x => x.DmatLink).NotNull().NotEmpty().WithMessage("DMAT link is required");            
        }
    }
}
