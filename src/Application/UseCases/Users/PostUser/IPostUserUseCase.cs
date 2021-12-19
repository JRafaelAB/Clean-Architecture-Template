using System.Threading.Tasks;
using Domain.DataObjects.Entities.User;

namespace Application.UseCases.Users.PostUser
{

    public interface IPostUserUseCase
    {
        Task Execute(UserEntity user);
    }
}