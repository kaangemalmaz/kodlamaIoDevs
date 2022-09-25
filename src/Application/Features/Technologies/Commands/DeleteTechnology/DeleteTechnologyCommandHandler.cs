using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly TechnologyBusinessRules _technologyBusinessRules;
        private readonly IMapper _mapper;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _technologyBusinessRules = technologyBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {

            Technology technology =  await _technologyRepository.GetAsync(t => t.Id == request.Id);

            //business rules
            await _technologyBusinessRules.TechnologyShouldExitsWhenRequested(technology);
            //business rules

            Technology deletedTechnology =  await _technologyRepository.DeleteAsync(technology);
            DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
            return deletedTechnologyDto;
        }
    }
}
