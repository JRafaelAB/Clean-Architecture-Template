using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace UnitTests.Repositories.UserRepository
{
    public class UserRepositoryTest
    {
        private readonly Mock<ClockContext> _clockContext;
        private readonly IUserRepository _repository;
        
        public UserRepositoryTest()
        {
            var mockSet = new Mock<DbSet<User>>();
            
            this._clockContext = new Mock<ClockContext>();
            this._repository = new Infrastructure.Repositories.UserRepository(this._clockContext.Object);
            
            
            this._clockContext.Setup(m => m.Users).Returns(mockSet.Object);
        }
        
        [Fact]
        public async Task TestingSucess_AddUser()
        {
            await this._repository.AddUser(DataSetup.UserDto);
            this._clockContext.Verify(clock => clock.Users.AddAsync(DataSetup.User, It.IsAny<CancellationToken>()));
        }
    }
}
