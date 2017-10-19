using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayChall.API.Dtos
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int RelationId { get; set; }
        public int PersonId { get; set; }
    }
}
