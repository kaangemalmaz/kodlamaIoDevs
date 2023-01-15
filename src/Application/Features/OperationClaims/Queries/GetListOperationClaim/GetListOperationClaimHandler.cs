using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimHandler : IRequestHandler<GetListOperationClaimRequest, OperationClaimListModal>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModal> Handle(GetListOperationClaimRequest request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = 
                await _operationClaimRepository.GetListAsync(
                    size: request.PageRequest.PageSize, 
                    index: request.PageRequest.Page);

            return _mapper.Map<OperationClaimListModal>(operationClaims);
        }
    }
}
