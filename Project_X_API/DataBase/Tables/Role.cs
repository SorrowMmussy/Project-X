using System.ComponentModel.DataAnnotations;

namespace Project_X_API.DataBase.Tables
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}