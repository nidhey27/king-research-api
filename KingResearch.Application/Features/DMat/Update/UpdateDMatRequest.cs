using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Update
{
    public class UpdateDMatRequest : IRequest<UpdateDMatResponse>
    {
        public int DMatId { get; set; }
        public string DmatName { get; set; }
        public string DmatLink { get; set; }        
        public string UpdateBy { get; set; }

    }
}
