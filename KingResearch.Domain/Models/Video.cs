using System;
using System.Collections.Generic;

#nullable disable

namespace KingResearch.Domain.Models
{
    public partial class Video
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public string VideoLink { get; set; }
        public string VideoDescption { get; set; }
        public string Type { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
