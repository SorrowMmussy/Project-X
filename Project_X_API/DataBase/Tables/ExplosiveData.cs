using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X_API.DataBase.Tables
{
    [Table(nameof(ExplosiveData))]
    public class ExplosiveData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(48)]
        public string Name { get; set; }
        
        [MaxLength(48)]
        public string Category { get; set; }
        
        [MaxLength(48)]
        public string ManufacturersCountry { get; set; }
        
        [MaxLength(48)]
        public string Caliber { get; set; }

        [MaxLength(48)]
        public string ExplosivePurposeId { get; set; }

        [MaxLength(48)]
        public string DetonatorTypeId { get; set; }
        
        public int Width { get; set; }
        
        public int Length { get; set; }

        public int Height { get; set; }

        public string Note { get; set; }

        public string Material { get; set; }

        public string Tier { get; set; }

        public string Assembly { get; set; }
    }
}