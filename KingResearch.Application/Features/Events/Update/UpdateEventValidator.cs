using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Events.Update
{
    public class UpdateEventValidator : AbstractValidator<UpdateEventRequest>
    {
        public UpdateEventValidator()
        {

            RuleFor(x => x).NotNull();
            RuleFor(x => x.EventId).NotNull().NotEqual(0).WithMessage("Event Id is required");
            RuleFor(x => x.EventName).NotNull().NotEmpty().WithMessage("Event Name is required");
            RuleFor(x => x.EventDescription).NotNull().NotEmpty().WithMessage("Event Description is required");
            RuleFor(x => x.EventDateTime).NotNull().WithMessage("Event Date Time required");
            RuleFor(x => x.EventContent).NotNull().NotEmpty().WithMessage("Event content is required");
        }
    }
}
