using Domain.DTOs;

namespace UnitTests.UseCases.Users.PostUser
{
    public static class DataSetup
    {
        public static UserDto GenerateUserDto()
        {
            return new UserDto("name", "login", "password", "salt");
        }
    }
}
