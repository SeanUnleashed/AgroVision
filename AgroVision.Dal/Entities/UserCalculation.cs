using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroVision.Dal.Entities
{
    [Table("UserCalculation")]
    public class UserCalculation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public double Hectares { get; set; }

        [Required]
        public double MinimimSprayRate { get; set; }

        [Required]
        public double LitersPerHectare { get; set; }

        [Required]
        public double AgentAmount { get; set; }

        [Required]
        public double WaterAmount { get; set; }

        public string CropType { get; set; }

        public string SprayingAgent { get; set; }
    }
}
