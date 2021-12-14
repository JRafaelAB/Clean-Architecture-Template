using System;

namespace Domain.Exceptions
{
    public class EntityConflictException : Exception
    {
        public EntityConflictException(string message) : base(message) 
        {
            
        }
    }
}
