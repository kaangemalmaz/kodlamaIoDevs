using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    internal class GetByIdOperationClaimHandler : IRequestHandler<GetByIdOperationClaimRequest, GetByIdOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetByIdOperationClaimHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdOperationClaimDto> Handle(GetByIdOperationClaimRequest request, CancellationToken cancellationToken)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(p => p.Id == request.Id);

            return _mapper.Map<GetByIdOperationClaimDto>(operationClaim);
        }
    }
}
