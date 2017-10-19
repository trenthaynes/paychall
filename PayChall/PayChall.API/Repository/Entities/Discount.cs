using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayChall.API.Repository.Entities
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscountId { get; set; }

        [Required]
        public decimal DiscountAmount { get; set; }

        [Required]
        [MaxLength(100)]
        public string DiscountName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Condition { get; set; }

        [Required]
        [MaxLength(75)]
        public string Field { get; set; }

        [Required]
        [MaxLength(400)]
        public string Expression { get; set; }
    }
}
