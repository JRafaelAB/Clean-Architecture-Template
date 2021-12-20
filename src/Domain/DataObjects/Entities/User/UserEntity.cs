using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Constants;
using Domain.DataAccess.Repositories;
using Domain.DataObjects.Database;
using Domain.Utils;

namespace Domain.DataObjects.Entities.User
{
    public class UserEntity : DatabaseMappedEntity<UserDbo>
    {
        public string Name { get; }
        public string Login { get; }
        public string Password { get; }
        public string Salt { get; }

        public UserEntity(IMapper mapper, IBaseRepository<UserDbo> repository, string name, string login, string password, string salt) : base(mapper, repository)
        {
            Name = name;
            Login = login;
            Password = password;
            Salt = salt;
        }
        
        public UserEntity(IMapper mapper, IUserRepository repository, string name, string login, string password) : base(mapper, repository)
        {
            Task.WaitAll(repository.ValidateExistingUser(login));
            
            this.Name = name;
            this.Login = login;
            
            var saltSize = Configuration.GetConfigurationValue<uint>(AppSettingsVariables.UserSaltSize);
            
            this.Salt = Cryptography.GenerateSalt(saltSize);
            this.Password = Cryptography.EncryptPassword(password, this.Salt);
        }

        #region Equals_Hash_Operators
        
        protected bool Equals(UserEntity other)
        {
            return this.Name == other.Name && this.Login == other.Login;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((UserEntity)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Login);
        }

        public static bool operator ==(UserEntity? left, UserEntity? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserEntity? left, UserEntity? right)
        {
            return !Equals(left, right);
        }
        
        #endregion
    }
}