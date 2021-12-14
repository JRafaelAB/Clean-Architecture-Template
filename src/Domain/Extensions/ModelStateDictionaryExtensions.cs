using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Domain.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static IEnumerable<string> GetErrorList(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
        }
    }
}
