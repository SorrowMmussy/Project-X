using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X_API.DataBase.Tables
{
    [Table(nameof(UserData))]
    public class UserData
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [MaxLength(30)]
        public string Email { get; set; }
        
        [MaxLength(60)]
        public string Address { get; set; }
        
        [MaxLength(20)]
        public string MobilePhone { get; set; }

        public virtual User User { get; set; }
    }
}