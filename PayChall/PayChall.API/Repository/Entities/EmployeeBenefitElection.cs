using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayChall.API.Repository.Entities
{
    public class EmployeeBenefitElection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeBenefitElectionId { get; set; }
        
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int BenefitTypeId { get; set; }
        [ForeignKey("BenefitTypeId")]
        public BenefitRecipientType BenefitType { get; set; }

        public ICollection<EmployeeBenefitElection> Dependents { get; set; }
    }
}
