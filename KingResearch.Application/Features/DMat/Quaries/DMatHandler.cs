using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Quaries
{
    public class DMatHandler : IRequestHandler<DMatRequest, DMatResponse>
    {
        private IBusinesRepository<Domain.Models.Dmat> _businesRepository;
        public DMatHandler(IBusinesRepository<Domain.Models.Dmat> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<DMatResponse> Handle(DMatRequest request, CancellationToken cancellationToken)
        {
            DMatResponse response = new DMatResponse();
            response.Dmats = _businesRepository.GetAll();
            return Task.FromResult(response);
        }
    }
}
