using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Videos.Update
{
    public class UpdateVideosValidator : AbstractValidator<UpdateVideoRequest>
    {
        public UpdateVideosValidator()
        {
            RuleFor(req => req).NotNull();
            RuleFor(x => x.VideoName).NotNull().NotEmpty().WithMessage("Video name required");
            RuleFor(x => x.VideoDescption).NotNull().NotEmpty().WithMessage("Video description is required");
            RuleFor(x => x.VideoLink).NotNull().NotEmpty().WithMessage("Video link is required");
        }
    }
}
