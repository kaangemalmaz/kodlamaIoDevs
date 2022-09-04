using Application.Features.ProgramingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage
{
    public class GetListProgramingLanguageQuery : IRequest<ProgramingLanguageListModal>
    {
        public PageRequest PageRequest { get; set; }



        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModal>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageListModal> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgramingLanguage> result = await _programingLanguageRepository
                    .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgramingLanguageListModal programingLanguageListModal = _mapper.Map<ProgramingLanguageListModal>(result);

                return programingLanguageListModal;
            }
        }
    }
}
