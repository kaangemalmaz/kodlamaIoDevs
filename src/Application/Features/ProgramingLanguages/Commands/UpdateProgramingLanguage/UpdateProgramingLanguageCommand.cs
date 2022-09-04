using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommand : IRequest<UpdatedProgramingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, UpdatedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _rules;

            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules rules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdatedProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _rules.ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);


                var mappedPL = _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(mappedPL);
                UpdatedProgramingLanguageDto updatedProgramLanguageDto = _mapper.Map<UpdatedProgramingLanguageDto>(updatedProgramingLanguage);
                return updatedProgramLanguageDto;
            }
        }
    }
}
