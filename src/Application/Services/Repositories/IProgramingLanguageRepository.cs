using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IProgramingLanguageRepository : IAsyncRepository<ProgramingLanguage>, IRepository<ProgramingLanguage>
    {
    }
}
