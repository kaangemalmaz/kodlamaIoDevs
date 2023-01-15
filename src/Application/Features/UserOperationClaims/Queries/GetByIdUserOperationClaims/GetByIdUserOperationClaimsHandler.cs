using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaims
{
    internal class GetByIdUserOperationClaimsHandler : IRequestHandler<GetByIdUserOperationClaimsRequest, GetByIdUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetByIdUserOperationClaimsHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserOperationClaimDto> Handle(GetByIdUserOperationClaimsRequest request, CancellationToken cancellationToken)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(p => p.Id == request.Id);

            return _mapper.Map<GetByIdUserOperationClaimDto>(userOperationClaim);
        }
    }
}
