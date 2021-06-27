using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Service.Delete
{
    public class DeleteServiceRequest : IRequest<DeleteServiceResponse>
    {
        public int ServiceId { get; set; }
    }
}
