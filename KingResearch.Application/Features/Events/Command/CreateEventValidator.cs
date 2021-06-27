using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Events.Command
{
   public  class CreateEventValidator :  AbstractValidator<CreateEventRequest>
    {
        public CreateEventValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.EventName).NotNull().NotEmpty().WithMessage("Event Name is required");
            RuleFor(x => x.EventDescription).NotNull().NotEmpty().WithMessage("Event Description is required");
            RuleFor(x => x.EventDateTime).NotNull().WithMessage("Event Date Time required");
            RuleFor(x => x.EventContent).NotNull().NotEmpty().WithMessage("Event content is required");
        }
    }

}
