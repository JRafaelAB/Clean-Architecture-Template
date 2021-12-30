using Domain.DataAccess.Repositories;
using Domain.DataObjects.Database;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<UserDbo>, IUserRepository
    {
        public UserRepository(CleanTemplateContext context) : base(context)
        {
        }
    }
}
