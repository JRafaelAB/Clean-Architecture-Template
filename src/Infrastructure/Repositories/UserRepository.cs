using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Resources;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ClockContext _context;

        public UserRepository(ClockContext context)
        {
            _context = context;
        }

        public async Task AddUser(UserDto userDto)
        {
            User userEntity = new(userDto);
            await this._context.Users.AddAsync(userEntity);
        }

        public async Task ValidateExistingUser(string login)
        {
            var user = await this._context.Users.Where(user => user.Login.Equals(login)).SingleOrDefaultAsync();

            if (user != null)
            {
                throw new EntityConflictException(Messages.LoginAlreadyRegistered);
            }
        }
    }
}
