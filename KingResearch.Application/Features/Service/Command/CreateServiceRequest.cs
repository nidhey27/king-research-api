using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Service.Command
{
    public class CreateServiceRequest : IRequest<CreateServiceResponse>
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Domain.Models.Service ToService()
        {
            return new Domain.Models.Service { CreatedBy = this.CreatedBy, CreatedOn = DateTime.Now, ServiceDescription = this.ServiceDescription, ServiceName = this.ServiceName, UpdatedBy = this.UpdatedBy, UpdatedOn = DateTime.Now };
        }
    }
}
