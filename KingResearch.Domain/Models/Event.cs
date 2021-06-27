using System;
using System.Collections.Generic;

#nullable disable

namespace KingResearch.Domain.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventVideoLink { get; set; }
        public string EventDescription { get; set; }
        public string EventContent { get; set; }
        public DateTime? EventDateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
