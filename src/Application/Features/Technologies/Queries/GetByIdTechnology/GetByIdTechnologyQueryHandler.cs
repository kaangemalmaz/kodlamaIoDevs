using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
        {
            Technology technology = await _technologyRepository.GetAsyncWithInclude(
                include: t => t.Include(t => t.ProgramingLanguage),
                predicate: t => t.Id == request.Id);

            GetByIdTechnologyDto getByIdTechnologyDto = _mapper.Map<GetByIdTechnologyDto>(technology);
            return getByIdTechnologyDto;
        }
    }
}
