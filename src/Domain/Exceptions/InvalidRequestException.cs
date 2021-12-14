using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Domain.Exceptions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class InvalidRequestException : Exception
    {
        [JsonProperty]
        public IList<string> ErrorMessages { get; }
        public InvalidRequestException(IEnumerable<string> errors)
        {
            this.ErrorMessages = errors.ToList();
        }
    }
}