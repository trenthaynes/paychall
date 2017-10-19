using Microsoft.EntityFrameworkCore;
using PayChall.API.Repository.Entities;

namespace PayChall.API.Repository.Entities
{
    public class BenefitsContext : DbContext
    {
        public BenefitsContext(DbContextOptions<BenefitsContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<BenefitRecipientType> BenefitRecipientTypes { get; set; }
        public DbSet<EmployeeBenefitElection> BenefitElections { get; set; }
        public DbSet<Meta> Meta { get; set; }
    }
}
