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

namespace KingResearch.Application.Features.Videos.Update
{
    public class UpdateVideoHandler : IRequestHandler<UpdateVideoRequest, UpdateVideoResponse>
    {
        private IBusinesRepository<Domain.Models.Video> _businesRepository;
        public UpdateVideoHandler(IBusinesRepository<Domain.Models.Video> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<UpdateVideoResponse> Handle(UpdateVideoRequest request, CancellationToken cancellationToken)
        {
            UpdateVideosValidator validator = new UpdateVideosValidator();
            ValidationResult validationResult = validator.Validate(request);
            if (validationResult?.Errors?.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Domain.Models.Video video =  _businesRepository.GetById(request.VideoId);

            if (video == null)
            {
                throw new ValidationException("No records found for the video id =" + request.VideoId);       
            }

            video.UpdateBy = request.UpdatedBy;
            video.UpdateOn = DateTime.Now;
            video.VideoDescption = request.VideoDescption;
            video.VideoLink = request.VideoLink;
            video.VideoName = request.VideoName;
            video.Type = request.Type;


            _businesRepository.Update(video);
            return Task.FromResult(new UpdateVideoResponse { Success = "Record updated successfully." });
        }
    }
}
