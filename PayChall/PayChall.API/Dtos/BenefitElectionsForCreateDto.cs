using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class BenefitElectionsForCreateDto
    {
        [Required]
        public int EmployeeId { get; set; }
        ICollection<BenefitElectionForCreateDto> Elections { get; set; } = new List<BenefitElectionForCreateDto>();
    }
}
