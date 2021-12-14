using System.Threading.Tasks;
using Domain.DTOs;

namespace Application.UseCases.Users.PostUser
{

    public interface IPostUserUseCase
    {
        Task Execute(UserDto user);
    }
}