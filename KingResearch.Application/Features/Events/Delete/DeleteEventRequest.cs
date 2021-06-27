using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Events.Delete
{
    public class DeleteEventRequest : IRequest<DeleteEventResponse>
    {
        public int EventId { get; set; }
    }
}
