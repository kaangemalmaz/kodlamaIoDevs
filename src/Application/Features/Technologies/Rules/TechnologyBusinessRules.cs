using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            Technology technology =  await _technologyRepository.GetAsync(t => t.Name == name);
            if (technology != null)
                throw new BusinessException("Can not be duplicated!");
        }

        public async Task TechnologyShouldExitsWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Technology does not exists.");
        }

    }
}
