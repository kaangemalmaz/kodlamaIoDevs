using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimRequest : IRequest
    {
        public int Id { get; set; }
    }
}
