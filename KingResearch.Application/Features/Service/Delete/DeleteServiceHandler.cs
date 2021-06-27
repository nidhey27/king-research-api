using KingResearch.Application.Exception;
using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.Service.Delete
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceRequest, DeleteServiceResponse>
    {
        private IBusinesRepository<Domain.Models.Service> _businesRepository;
        public DeleteServiceHandler(IBusinesRepository<Domain.Models.Service> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<DeleteServiceResponse> Handle(DeleteServiceRequest request, CancellationToken cancellationToken)
        {
            if (request?.ServiceId == 0)
            {
                throw new ValidationException("Service Id request");
            }
            _businesRepository.Remove(_businesRepository.GetById(request.ServiceId));

            return Task.FromResult(new DeleteServiceResponse { Success = "Service deleted successfully." });
        }
    }
}
