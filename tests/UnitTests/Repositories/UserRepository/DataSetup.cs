using Domain.DTOs;
using Domain.Entities;

namespace UnitTests.Repositories.UserRepository
{
    public static class DataSetup
    {
        public static readonly UserDto UserDto = new ("name", "login", "password", "salt");

        public static readonly User User = new()
        {
            Name = "name",
            Login = "login",
            Password = "password",
            Salt = "salt"
        };
    }
}
