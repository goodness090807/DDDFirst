using System.ComponentModel.DataAnnotations;

namespace CMS.API.Controllers.Users.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
