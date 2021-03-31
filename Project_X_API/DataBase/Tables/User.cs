using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X_API.DataBase.Tables
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(60)]
        public string PasswordHash { get; set; }

        [MaxLength(60)]
        public string OldPasswordHash { get; set; }

        public int WrongLoginAttempts { get; set; }

        public virtual UserData UserData { get; set; }
    }
}