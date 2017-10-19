using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class CostDto
    {
        public decimal Amount { get; set; }
        public int BenefitRecipientTypeId { get; set; }
        public string BenefitRecipientTypeName { get; set; }
    }
}
