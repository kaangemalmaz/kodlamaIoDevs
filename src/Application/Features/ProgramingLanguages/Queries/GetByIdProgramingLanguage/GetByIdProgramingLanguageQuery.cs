using Application.Features.ProgramingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage
{
    public class GetByIdProgramingLanguageQuery : IRequest<ProgramingLanguageGetByIdDto>
    {
        public int Id { get; set; }



        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, ProgramingLanguageGetByIdDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;

            public GetByIdProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageGetByIdDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(pl => pl.Id == request.Id);
                ProgramingLanguageGetByIdDto programingLanguageGetByIdDto = _mapper.Map<ProgramingLanguageGetByIdDto>(programingLanguage);
                return programingLanguageGetByIdDto;
            }
        }
    }
}
