using System.Threading.Tasks;
using Application.UseCases.Users.PostUser;
using Domain.DTOs;
using Domain.Models.Requests;
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

        public UserController(IPostUserUseCase useCase)
        {
            _useCase = useCase;
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
            await _useCase.Execute(new UserDto(request));
            return NoContent();
        }
    }
}