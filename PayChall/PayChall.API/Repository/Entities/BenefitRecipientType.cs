using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayChall.API.Repository.Entities
{
    public class BenefitRecipientType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BenefitRecipientTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Label { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
