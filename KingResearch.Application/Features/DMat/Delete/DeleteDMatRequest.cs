using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Application.Features.DMat.Delete
{
    public class DeleteDMatRequest : IRequest<DeleteDMatResponse>
    {
        public int DMatId { get; set; }
    }
}
