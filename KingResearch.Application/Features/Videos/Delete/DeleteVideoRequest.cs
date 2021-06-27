using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Videos.Delete
{
    public class DeleteVideoRequest : IRequest<DeleteVideoResponse>
    {
        public int VideoId { get; set; }
    }
}
