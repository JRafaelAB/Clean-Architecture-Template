using System.Threading.Tasks;
using Application.UseCases.Users.PostUser;
using Domain.DataObjects.Entities.Factories;
using Domain.DataObjects.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.v1.UseCases.Users.PostUser
{
    /// <summary>
    /// UserController
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class UserController : BaseController
    {
        private readonly IPostUserUseCase _useCase;
        private readonly IUserEntityFactory _userEntityFactory;

        public UserController(IPostUserUseCase useCase, IUserEntityFactory userEntityFactory)
        {
            _useCase = useCase;
            _userEntityFactory = userEntityFactory;
        }
        
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <response code="204">Success</response>
        /// <param name="request"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUser([FromBody] PostUserRequest request)
        {
            ValidateRequest(request);
            await _useCase.Execute(_userEntityFactory.CreateNew(request));
            return NoContent();
        }
    }
}