using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class BenefitElectionDto
    {
        public PersonDto Person { get; set; }
        public CostDto Cost { get; set; }
        public int? DiscountId { get; set; }
        public bool HasDiscount => DiscountId.HasValue && DiscountId.Value > 0;
    }
}
