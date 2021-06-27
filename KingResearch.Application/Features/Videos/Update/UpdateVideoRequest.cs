using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Videos.Update
{
    public class UpdateVideoRequest : IRequest<UpdateVideoResponse>
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public string VideoLink { get; set; }
        public string VideoDescption { get; set; }
        public string Type { get; set; }        
        public string UpdatedBy { get; set; }


    }
}
