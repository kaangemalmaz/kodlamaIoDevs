using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimHandler : IRequestHandler<UpdateOperationClaimRequest>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateOperationClaimHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOperationClaimRequest request, CancellationToken cancellationToken)
        {
            OperationClaim oldOperationClaim =  await _operationClaimRepository.GetAsync(o=>o.Id == request.Id);
            if (oldOperationClaim == null) throw new BusinessException("Not Found");

            await _operationClaimRepository.UpdateAsync(_mapper.Map<UpdateOperationClaimRequest, OperationClaim>(request, oldOperationClaim));

            return Unit.Value;
        }
    }
}
