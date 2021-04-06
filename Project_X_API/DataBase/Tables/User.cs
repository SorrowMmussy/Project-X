using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X_API.DataBase.Tables
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(60)]
        public string PasswordHash { get; set; }

        [MaxLength(60)]
        public string OldPasswordHash { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string MobilePhone { get; set; }

        public int WrongLoginAttempts { get; set; }

        public virtual Role Role { get; set; }

        public virtual List<TokenValidation> Tokens { get; set; }
    }
}