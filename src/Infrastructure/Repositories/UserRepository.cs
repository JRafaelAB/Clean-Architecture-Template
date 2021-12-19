using System.Linq;
using System.Threading.Tasks;
using Domain.DataAccess.Repositories;
using Domain.DataObjects.DatabaseObjects;
using Domain.Exceptions;
using Domain.Resources;
using Dommel;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ClockContext _context;

        public UserRepository(ClockContext context)
        {
            _context = context;
        }

        public async Task Add(UserDbo user)
        {
            await this._context.Connection.InsertAsync(user);
        }

        public async Task ValidateExistingUser(string login)
        {
            var user = (await this._context.Connection.SelectAsync<UserDbo>(user => user.Login == login)).FirstOrDefault();

            if (user != null)
            {
                throw new EntityConflictException(Messages.LoginAlreadyRegistered);
            }
        }
    }
}
