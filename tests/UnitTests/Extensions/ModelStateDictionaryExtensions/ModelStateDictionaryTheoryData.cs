using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;

namespace UnitTests.Extensions.ModelStateDictionaryExtensions
{
    public class ModelStateDictionaryTheoryData : TheoryData<ModelStateDictionary>
    {
        public ModelStateDictionaryTheoryData()
        {
            this.Add(GenerateNewModelState(true));
            this.Add(GenerateNewModelState(false));
        }
        
        public static ModelStateDictionary GenerateNewModelState(bool withErrors)
        {
            ModelStateDictionary modelState = new ();
            
            if (withErrors)
            {
                modelState.AddModelError("Name", "Name is Required");
                modelState.AddModelError("Password", "Password is Required");
                modelState.AddModelError("Login", "Login is Required");
            }

            return modelState;
        }
    }
}
