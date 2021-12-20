using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Constants;
using Domain.Enums;

namespace Domain.DataObjects.Database
{
    [Table(TableNames.ClockTable)]
    public class ClockDbo
    {
        public long Id { get; init; }
        public ClockType Type { get; init; }
        public DateTime Time { get; init; }
        public long IdUser { get; init; }
        public UserDbo? User { get; init; }

        #region Equals_Hash_Operators
        
        protected bool Equals(ClockDbo other)
        {
            return Type == other.Type && Time.Equals(other.Time) && IdUser == other.IdUser;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((ClockDbo)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Type, Time, IdUser);
        }

        public static bool operator ==(ClockDbo? left, ClockDbo? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ClockDbo? left, ClockDbo? right)
        {
            return !Equals(left, right);
        }
        
        #endregion
    }
}
