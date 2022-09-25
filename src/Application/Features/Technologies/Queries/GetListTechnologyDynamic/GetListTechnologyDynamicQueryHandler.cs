using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetListTechnologyDynamic
{
    public class GetListTechnologyDynamicQueryHandler : IRequestHandler<GetListTechnologyDynamicQuery, TechnologyListModel>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetListTechnologyDynamicQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<TechnologyListModel> Handle(GetListTechnologyDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> mappedTechnology = await _technologyRepository.GetListByDynamicAsync(
                dynamic: request.Dynamic,
                include: (t => t.Include(t => t.ProgramingLanguage)),
                index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            TechnologyListModel technologyListModel = _mapper.Map<TechnologyListModel>(mappedTechnology);

            return technologyListModel;
        }
    }
}
