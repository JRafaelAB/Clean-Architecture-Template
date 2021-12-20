using System.Threading.Tasks;
using Domain.DataObjects.Database;

namespace Domain.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<UserDbo>
    {
        Task ValidateExistingUser(string login);
    }
}
