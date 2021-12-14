using System.Threading.Tasks;
using Application.UseCases.Users.PostUser;
using Domain.Constants;
using Domain.DTOs;
using Domain.Repositories;
using Domain.UnitOfWork;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace UnitTests.UseCases.Users.PostUser
{
    public class PostUserUseCaseTest
    {
        private readonly IPostUserUseCase _useCase;
        private readonly Mock<IUserRepository> _userRepository = new();
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        
        public PostUserUseCaseTest()
        {
            Mock<IConfigurationSection> mockSection = new();
            mockSection.Setup(section => section.Value).Returns("22");
            
            Mock<IConfiguration> mockConfig = new();
            mockConfig.Setup(x => x.GetSection(AppSettingsVariables.UserSaltSize)).Returns(mockSection.Object);
            
            this._useCase = new PostUserUseCase(mockConfig.Object, _userRepository.Object, _unitOfWork.Object);
        }

        [Fact]
        public async Task TestingSuccess_PostUser()
        {
            UserDto expectedUser = DataSetup.GenerateUserDto();
            UserDto user = DataSetup.GenerateUserDto();
            
            await this._useCase.Execute(user);
            
            var expectedPassword = Cryptography.EncryptPassword(expectedUser.Password, user.Salt);
            expectedUser.SetCryptographyCredentials(expectedPassword, user.Salt);

            this._userRepository.Verify(repository => repository.AddUser(expectedUser));
            this._unitOfWork.Verify(unitOfWork => unitOfWork.Save(), Times.Once);
            Assert.Equal(expectedUser, user);
            Assert.Equal(expectedPassword, user.Password);
        }
        
    }
}
