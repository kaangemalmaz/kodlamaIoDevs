using Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimRequest : IRequest<CreatedOperationClaimDto>
    {
        public string Name { get; set; }
    }
}
