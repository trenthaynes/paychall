using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayChall.API.Repository.Entities
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public bool IsEmployee { get; set; }
        public decimal Salary { get; set; }
        public int PayPeriods { get; set; }
        public int RelationId { get; set; }
    }
}
