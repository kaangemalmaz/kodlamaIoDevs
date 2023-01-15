using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    internal class RefreshTokenRepository : EfRepositoryBase<RefreshToken, KodlamaIoDevsDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(KodlamaIoDevsDbContext context) : base(context)
        {
        }
    }
}
