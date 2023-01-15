using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, KodlamaIoDevsDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(KodlamaIoDevsDbContext context) : base(context)
        {
        }
    }
}
