using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class BenefitElectionForCreateDto
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public CostDto Cost { get; set; }
        public int? DiscountId { get; set; }
    }
}
