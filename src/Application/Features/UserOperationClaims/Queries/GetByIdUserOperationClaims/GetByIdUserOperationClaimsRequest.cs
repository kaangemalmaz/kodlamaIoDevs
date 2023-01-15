using Application.Features.OperationClaims.Dtos;
using Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaims
{
    public class GetByIdUserOperationClaimsRequest : IRequest<GetByIdUserOperationClaimDto>
    {
        public int Id { get; set; }
    }
}
