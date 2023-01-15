using Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaims
{
    public class GetListUserOperationClaimsRequest : IRequest<UserOperationClaimListModal>
    {
        public PageRequest PageRequest { get; set; }
    }
}
