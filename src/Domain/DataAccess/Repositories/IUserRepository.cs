using System.Threading.Tasks;
using Domain.DataObjects.DatabaseObjects;

namespace Domain.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<UserDbo>
    {
        Task ValidateExistingUser(string login);
    }
}
