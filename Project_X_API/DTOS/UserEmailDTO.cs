using System.ComponentModel.DataAnnotations;

namespace Project_X_API.DTOS
{
    public class UserEmailDTO
    {
        [Required]
        public string Email { get; set; }
    }
}