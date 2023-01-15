using MediatR;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
