using KingResearch.Application.Exception;
using KingResearch.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Delete
{
    public class DeleteDMatHandler : IRequestHandler<DeleteDMatRequest, DeleteDMatResponse>
    {
        private IBusinesRepository<Domain.Models.Dmat> _businesRepository;
        public DeleteDMatHandler(IBusinesRepository<Domain.Models.Dmat> businesRepository)
        {
            _businesRepository = businesRepository;
        }
        public Task<DeleteDMatResponse> Handle(DeleteDMatRequest request, CancellationToken cancellationToken)
        {
            if (request?.DMatId == 0)
            {
                throw new ValidationException("DMat Id required");
            }
            _businesRepository.Remove(_businesRepository.GetById(request.DMatId));

            return Task.FromResult(new DeleteDMatResponse { Success = "Video deleted successfully." });

        }
    }
}
