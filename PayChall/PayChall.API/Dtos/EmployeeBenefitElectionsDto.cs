using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class EmployeeBenefitElectionsDto
    {
        public EmployeeDto Employee { get; set; }
        public ICollection<BenefitElectionDto> Elections { get; set; } = new List<BenefitElectionDto>();
    }
}
