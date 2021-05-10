using System.ComponentModel.DataAnnotations;

namespace Project_X_API.DTOS
{
    public class AddUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Token { get; set; }
    }
}