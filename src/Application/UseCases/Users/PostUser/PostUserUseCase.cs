using System.Threading.Tasks;
using Domain.Constants;
using Domain.DTOs;
using Domain.Repositories;
using Domain.UnitOfWork;
using Domain.Utils;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.Users.PostUser
{
    public class PostUserUseCase : IPostUserUseCase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PostUserUseCase(IConfiguration configuration, IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task Execute(UserDto user)
        {
            await this._repository.ValidateExistingUser(user.Login);
                
            var saltSize = this._configuration.GetValue<uint>(AppSettingsVariables.UserSaltSize);
            var salt = Cryptography.GenerateSalt(saltSize);
            var password = Cryptography.EncryptPassword(user.Password, salt);

            user.SetCryptographyCredentials(password, salt);

            await this._repository.AddUser(user);
            await this._unitOfWork.Save();
        }
    }
}