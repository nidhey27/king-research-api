using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Events.Update
{
    public class UpdateEventRequest :IRequest<UpdateEventResponse>
    {
        public int EventId { get; set; }

        public string EventName { get; set; }
        public string EventVideoLink { get; set; }
        public string EventDescription { get; set; }
        public string EventContent { get; set; }
        public DateTime? EventDateTime { get; set; }        
        public string UpdateBy { get; set; }
    }
}
