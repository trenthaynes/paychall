using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class MetaDto
    {
        public int PayPeriods { get; set; }
        public decimal BasePay { get; set; }
        public ICollection<CostDto> Costs { get; set; } = new List<CostDto>();
        public ICollection<DiscountDto> Discounts { get; set; } = new List<DiscountDto>();
    }
}
