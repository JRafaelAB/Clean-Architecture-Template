using System.ComponentModel.DataAnnotations;

namespace Domain.DataObjects.Models.Requests
{
    public class PostUserRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; }
        
        [Required(AllowEmptyStrings = false)]
        public string Login { get; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; }

        public PostUserRequest(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }
    }
}