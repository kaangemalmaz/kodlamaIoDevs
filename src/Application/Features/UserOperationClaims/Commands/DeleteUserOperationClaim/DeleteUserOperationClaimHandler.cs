using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimHandler : IRequestHandler<DeleteUserOperationClaimRequest>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public DeleteUserOperationClaimHandler(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<Unit> Handle(DeleteUserOperationClaimRequest request, CancellationToken cancellationToken)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(o => o.Id == request.Id);
            if (userOperationClaim == null) throw new BusinessException("User Operation Claim not found");
            await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
            return Unit.Value;
        }
    }
}
