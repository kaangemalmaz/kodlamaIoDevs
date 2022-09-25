using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnologyDynamic;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery : IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
