using Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimRequest : IRequest<GetByIdOperationClaimDto>
    {
        public int Id { get; set; }
    }
}
