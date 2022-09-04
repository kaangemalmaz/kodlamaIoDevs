using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProgramingLanguageRepository : EfRepositoryBase<ProgramingLanguage, KodlamaIoDevsDbContext>, IProgramingLanguageRepository
    {
        public ProgramingLanguageRepository(KodlamaIoDevsDbContext context) : base(context)
        {
        }
    }
}
