using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimRequest : IRequest
    {
        public int Id { get; set; }
    }
}
