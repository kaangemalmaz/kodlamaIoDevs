using Application.Features.OperationClaims.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimRequest : IRequest<OperationClaimListModal>
    {
        public PageRequest PageRequest { get; set; }
    }
}
