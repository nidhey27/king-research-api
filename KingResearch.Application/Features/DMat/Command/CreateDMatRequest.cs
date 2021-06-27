using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Command
{
    public class CreateDMatRequest : IRequest<CreateDMatResponse>
    {
        
        public string DmatName { get; set; }
        public string DmatLink { get; set; }
        public string CreateBy { get; set; }        
        public string UpdateBy { get; set; }        
        public Domain.Models.Dmat ToDmat()
        {
            return new Domain.Models.Dmat
            {
                CreateBy = this.CreateBy,
                CreateOn = DateTime.Now,
                DmatLink = this.DmatLink,
                DmatName = this.DmatName,
                UpdateBy = this.UpdateBy,
                UpdatedOn = DateTime.Now                
            };
        }
    }
}
