using System;
using System.Collections.Generic;

#nullable disable

namespace KingResearch.Domain.Models
{
    public partial class Dmat
    {
        public int DmatId { get; set; }
        public string DmatName { get; set; }
        public string DmatLink { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
