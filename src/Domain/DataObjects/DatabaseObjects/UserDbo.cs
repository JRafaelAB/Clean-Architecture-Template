using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Constants;
#pragma warning disable CS8618

namespace Domain.DataObjects.DatabaseObjects
{
    [Table(TableNames.UserTable)]
    public class UserDbo
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public string Salt { get; init; }
        public IEnumerable<ClockDbo>? Clocks { get; init; }

        #region Equals_Hash_Operators
        
        protected bool Equals(UserDbo other)
        {
            return Name == other.Name && Login == other.Login;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((UserDbo)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Login);
        }

        public static bool operator ==(UserDbo? left, UserDbo? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserDbo? left, UserDbo? right)
        {
            return !Equals(left, right);
        }
        
        #endregion
    }
}
