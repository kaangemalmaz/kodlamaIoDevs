using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    
    public class CreateOperationClaimHandler : IRequestHandler<CreateOperationClaimRequest, CreatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public CreateOperationClaimHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimRequest request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim =  await _operationClaimRepository.AddAsync(_mapper.Map<OperationClaim>(request));    
            CreatedOperationClaimDto createdOperationClaim = _mapper.Map<CreatedOperationClaimDto>(operationClaim);
            return createdOperationClaim;
        }
    }
}
