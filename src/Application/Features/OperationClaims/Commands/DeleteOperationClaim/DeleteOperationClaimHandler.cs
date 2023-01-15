using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimHandler : IRequestHandler<DeleteOperationClaimRequest>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public DeleteOperationClaimHandler(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<Unit> Handle(DeleteOperationClaimRequest request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
            if (operationClaim == null) throw new BusinessException("Operation Claim not found");
            await _operationClaimRepository.DeleteAsync(operationClaim);
            return Unit.Value;
        }
    }
}
