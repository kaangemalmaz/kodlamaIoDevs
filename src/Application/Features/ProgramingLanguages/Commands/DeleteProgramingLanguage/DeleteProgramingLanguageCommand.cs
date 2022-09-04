using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageCommand : IRequest<DeletedProgramingLanguageDto>
    {
        public int Id { get; set; }


        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeletedProgramingLanguageDto>
        {

            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _rules;

            public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules rules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _rules = rules;
            }


            public async Task<DeletedProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {

                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

                await _rules.ProgramingLanguageShouldExitsWhenRequested(programingLanguage);


                ProgramingLanguage deletedProgramingLanguage = await _programingLanguageRepository.DeleteAsync(programingLanguage);
                DeletedProgramingLanguageDto deletedProgramLanguageDto = _mapper.Map<DeletedProgramingLanguageDto>(deletedProgramingLanguage);
                return deletedProgramLanguageDto;
            }
        }
    }

}
