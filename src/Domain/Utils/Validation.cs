using System;
using Domain.Resources;

namespace Domain.Utils
{
    public static class Validation
    {
        public static void ValidateNullArgument(this object? obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentException(null, paramName);
            }
        }

        public static void ValidateStringArgumentNotNullOrEmpty(this string? argument, string? paramName = null)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException(Messages.ArgumentStringNullOrEmpty, paramName);
            }
        }
    }
}