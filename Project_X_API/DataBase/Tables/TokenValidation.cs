using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X_API.DataBase.Tables
{
    [Table(nameof(TokenValidation))]
    public class TokenValidation
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Token { get; set; }

        public DateTime TokenExpires { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}