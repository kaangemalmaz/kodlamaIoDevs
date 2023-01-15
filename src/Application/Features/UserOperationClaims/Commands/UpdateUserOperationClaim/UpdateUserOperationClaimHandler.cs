using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimHandler : IRequestHandler<UpdateUserOperationClaimRequest>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserOperationClaimRequest request, CancellationToken cancellationToken)
        {
            UserOperationClaim oldUserOperationClaim =  await _userOperationClaimRepository.GetAsync(o=>o.Id == request.Id);
            if (oldUserOperationClaim == null) throw new BusinessException("Not Found");

            await _userOperationClaimRepository.UpdateAsync(_mapper.Map<UpdateUserOperationClaimRequest, UserOperationClaim>(request, oldUserOperationClaim));

            return Unit.Value;
        }
    }
}
