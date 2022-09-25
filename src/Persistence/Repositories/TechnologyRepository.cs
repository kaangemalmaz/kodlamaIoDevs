using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, KodlamaIoDevsDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(KodlamaIoDevsDbContext context) : base(context)
        {
        }
    }
}
