using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;

        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public async Task ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("ProgramingLanguage name exists.");
        }

        public async Task ProgramingLanguageShouldExitsWhenRequested(ProgramingLanguage programingLanguage)
        {
            if (programingLanguage == null) throw new BusinessException("ProgramingLanguage does not exists.");
        }
    }
}
