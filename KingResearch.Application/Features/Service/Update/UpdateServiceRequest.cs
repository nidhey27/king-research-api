using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Service.Update
{
    public class UpdateServiceRequest : IRequest<UpdateServiceResponse>
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServiceId { get; set; }        
        public string UpdatedBy { get; set; }

        public Domain.Models.Service ToService()
        {
            return new Domain.Models.Service { ServiceId = this.ServiceId, ServiceDescription = this.ServiceDescription, ServiceName = this.ServiceName, UpdatedBy = this.UpdatedBy, UpdatedOn = DateTime.Now };
        }
    }
}
