using Application.Features.ProgramingLanguages.Constants;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    
    public class CreateProgramingLanguageCommand : IRequest<CreatedProgramingLanguageDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
            ProgrammingLanguageRoles.ProgrammingLanguageAdmin,
            ProgrammingLanguageRoles.ProgrammingLanguageCreate
        };

        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, CreatedProgramingLanguageDto>
        {

            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _rules;

            public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules rules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _rules.ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);


                var mappedPL = _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage createdProgramingLanguage =  await _programingLanguageRepository.AddAsync(mappedPL);
                CreatedProgramingLanguageDto createdProgramLanguageDto = _mapper.Map<CreatedProgramingLanguageDto>(createdProgramingLanguage);
                return createdProgramLanguageDto;

            }
        }


    }
}
