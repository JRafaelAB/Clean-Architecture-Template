using System.Collections.Generic;
using System.Linq;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;

namespace UnitTests.Extensions.ModelStateDictionaryExtensions
{
    public class ModelStateDictionaryExtensionsTest
    {
        [Theory]
        [ClassData(typeof(ModelStateDictionaryTheoryData))]
        public void TestingSucess_GetErrorList(ModelStateDictionary modelState)
        {
            IEnumerable<string> errorList = modelState.GetErrorList();
            IEnumerable<string>  expectedErrorList = modelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
            
            Assert.Equal(expectedErrorList.Count(), errorList.Count());
            
            foreach (var error in errorList)
            {
                Assert.Contains(error, expectedErrorList);
            }
        }
        
    }
}
