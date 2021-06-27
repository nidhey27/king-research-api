using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Events.Command
{
   public class CreateEventRequest : IRequest<CreateEventResponse>
    {
        public string EventName { get; set; }
        public string EventVideoLink { get; set; }
        public string EventDescription { get; set; }
        public string EventContent { get; set; }
        public DateTime? EventDateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }

        public Domain.Models.Event ToEvent()
        {
            return new Domain.Models.Event
            {
                CreateBy = this.CreateBy,
                CreateOn = DateTime.Now,
                EventContent = this.EventContent,
                EventDateTime = this.EventDateTime,
                EventDescription = this.EventDescription,
                EventName = this.EventName,
                EventVideoLink = this.EventVideoLink,
                UpdateBy = this.UpdateBy,
                UpdateOn = DateTime.Now
            };
        }


    }

}
