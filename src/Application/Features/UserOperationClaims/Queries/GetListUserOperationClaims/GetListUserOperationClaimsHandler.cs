using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaims
{
    public class GetListUserOperationClaimsHandler : IRequestHandler<GetListUserOperationClaimsRequest, UserOperationClaimListModal>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimsHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModal> Handle(GetListUserOperationClaimsRequest request, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaims = 
                await _userOperationClaimRepository.GetListAsync(
                    size: request.PageRequest.PageSize, 
                    index: request.PageRequest.Page);

            return _mapper.Map<UserOperationClaimListModal>(userOperationClaims);
        }
    }
}
