using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Service.Quaries
{
    public class ServiceHandler : IRequestHandler<ServiceRequest, ServiceResponse>
    {
        private IBusinesRepository<Domain.Models.Service> _businesRepository;
        public ServiceHandler(IBusinesRepository<Domain.Models.Service> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<ServiceResponse> Handle(ServiceRequest request, CancellationToken cancellationToken)
        {
            ServiceResponse response = new ServiceResponse();
            response.Services = _businesRepository.GetAll();
            return Task.FromResult(response);
        }
    }
}
