using System;
using System.Collections.Generic;
using Domain.DTOs;

namespace Domain.Entities
{
    public class User
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public string Salt { get; init; }
        public IEnumerable<Clock>? Clocks { get; init; }

        public User()
        {
            
        }
        
        public User(UserDto dto)
        {
            Name = dto.Name;
            Login = dto.Login;
            Password = dto.Password;
            Salt = dto.Salt;
        }
        
        protected bool Equals(User other)
        {
            return Name == other.Name && Login == other.Login && Password == other.Password && Salt == other.Salt;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Login, Password, Salt);
        }

        public static bool operator ==(User? left, User? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(User? left, User? right)
        {
            return !Equals(left, right);
        }
    }
}
