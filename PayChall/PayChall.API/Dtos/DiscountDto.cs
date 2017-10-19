using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class DiscountDto
    {
        public decimal DiscountAmount { get; set; }
        public string DiscountName { get; set; }
        public string DiscountFormula { get; set; }
        public string DiscountCriteria { get; set; }
    }
}
