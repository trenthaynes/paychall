using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get
            {
                return FirstName + " " + LastName;
            }
        }
        public int EmployeeId { get; set; }

        ICollection<PersonDto> Dependents { get; set; } = new List<PersonDto>();
    }
}
