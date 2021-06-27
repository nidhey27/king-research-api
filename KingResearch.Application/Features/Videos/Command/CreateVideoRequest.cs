using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Videos.Command
{
    public class CreateVideoRequest : IRequest<CreateVideoResponse>
    {
        public string VideoName { get; set; }
        public string VideoLink { get; set; }
        public string VideoDescption { get; set; }
        public string Type { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Domain.Models.Video ToVideo()
        {
            return new Domain.Models.Video
            {
                CreatedBy = this.CreatedBy,
                CreateOn = DateTime.Now,
                VideoName = this.VideoName,
                VideoDescption = this.VideoDescption,
                VideoLink = this.VideoLink,
                Type = this.Type,
                UpdateBy = this.UpdatedBy,
                UpdateOn = DateTime.Now
            };
        }
    }
}
