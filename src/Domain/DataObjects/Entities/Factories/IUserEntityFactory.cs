using Domain.DataObjects.DatabaseObjects;
using Domain.DataObjects.Entities.User;
using Domain.DataObjects.Models.Requests;

namespace Domain.DataObjects.Entities.Factories
{
    public interface IUserEntityFactory
    {
        UserEntity CreateNew(PostUserRequest request);
        UserEntity CreateNew(UserDbo dbo);
    }
}
