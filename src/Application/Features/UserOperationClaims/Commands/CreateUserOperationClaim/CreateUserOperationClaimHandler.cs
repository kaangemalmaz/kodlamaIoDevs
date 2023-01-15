using Application.Features.OperationClaims.Dtos;
using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    
    public class CreateUserOperationClaimsHandler : IRequestHandler<CreateUserOperationClaimRequest, CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public CreateUserOperationClaimsHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimRequest request, CancellationToken cancellationToken)
        {
            UserOperationClaim operationClaim =  await _userOperationClaimRepository.AddAsync(_mapper.Map<UserOperationClaim>(request));
            CreatedUserOperationClaimDto createdUserOperationClaim = _mapper.Map<CreatedUserOperationClaimDto>(operationClaim);
            return createdUserOperationClaim;
        }
    }
}
