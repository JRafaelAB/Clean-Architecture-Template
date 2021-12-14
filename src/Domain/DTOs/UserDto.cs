using System;
using Domain.Entities;
using Domain.Models.Requests;

namespace Domain.DTOs
{
    public class UserDto
    {
        public string Name { get; }
        public string Login { get; }
        public string Password { get; private set; }
        public string Salt { get; private set; }

        public UserDto(User user)
        {
            this.Name = user.Name;
            this.Login = user.Login;
            this.Password = user.Password;
            this.Salt = user.Salt;
        }

        public UserDto(string name, string login, string password, string salt)
        {
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.Salt = salt;
        }

        public UserDto(PostUserRequest request)
        {
            this.Name = request.Name;
            this.Login = request.Login;
            this.Password = request.Password;
            this.Salt = string.Empty;
        }

        public void SetCryptographyCredentials(string password, string salt)
        {
            this.Password = password;
            this.Salt = salt;
        }

        protected bool Equals(UserDto other)
        {
            return this.Name == other.Name && this.Login == other.Login && this.Password == other.Password && this.Salt == other.Salt;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((UserDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Login);
        }

        public static bool operator ==(UserDto? left, UserDto? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserDto? left, UserDto? right)
        {
            return !Equals(left, right);
        }
    }
}