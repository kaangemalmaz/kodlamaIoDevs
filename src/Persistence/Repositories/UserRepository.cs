using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, KodlamaIoDevsDbContext>, IUserRepository
    {
        public UserRepository(KodlamaIoDevsDbContext context) : base(context)
        {
        }
    }
}
