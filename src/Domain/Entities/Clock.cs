using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Clock
    {
        public long Id { get; init; }
        public ClockType Type { get; }
        public DateTime Time { get; }
        public long IdUser { get; }
        public User? User { get; init; }
        
        public Clock(ClockType type, DateTime time, long idUser)
        {
            Type = type;
            Time = time;
            IdUser = idUser;
        }
        
        protected bool Equals(Clock other)
        {
            return Type == other.Type && Time.Equals(other.Time) && IdUser == other.IdUser;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Clock)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Type, Time, IdUser);
        }

        public static bool operator ==(Clock? left, Clock? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Clock? left, Clock? right)
        {
            return !Equals(left, right);
        }
    }
}
