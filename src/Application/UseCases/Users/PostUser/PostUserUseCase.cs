using System.Threading.Tasks;
using Domain.DataAccess.UnitOfWork;
using Domain.DataObjects.Entities.User;

namespace Application.UseCases.Users.PostUser
{
    public class PostUserUseCase : IPostUserUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostUserUseCase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task Execute(UserEntity user)
        {
            await user.AddToDatabase();
            await this._unitOfWork.Save();
        }
    }
}