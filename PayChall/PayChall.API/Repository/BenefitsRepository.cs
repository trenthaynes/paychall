using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayChall.API.Dtos;
using PayChall.API.Repository.Entities;

namespace PayChall.API.Repository
{
    public class BenefitsRepository : IBenefitsRepository
    {
        private BenefitsContext _ctx;
        public BenefitsRepository(BenefitsContext benesCtx)
        {
            _ctx = benesCtx;
        }

        public EmployeeBenefitElectionsDto AddElections(int id, BenefitElectionsForCreateDto elections)
        {
            throw new NotImplementedException();
        }

        public bool EmployeeExists(int id)
        {
            return _ctx.People.Any(p => p.PersonId == id);
        }

        public IEnumerable<CostDto> GetCosts()
        {
            var brts = _ctx.BenefitRecipientTypes.ToList();
            if (!brts.Any())
            {
                return null;
            }
            return brts.Select(b => new CostDto()
            {
                Amount = b.Cost,
                BenefitRecipientTypeId = b.BenefitRecipientTypeId,
                BenefitRecipientTypeName = b.Label
            }).ToList();
        }

        public IEnumerable<DiscountDto> GetDiscounts()
        {
            var discs = _ctx.Discounts.ToList();
            if (!discs.Any())
            {
                return null;
            }
            return discs.Select(d => new DiscountDto()
            {
                DiscountAmount = d.DiscountAmount,
                DiscountCriteria = d.Condition,
                DiscountFormula = d.Expression,
                DiscountName = d.DiscountName
            }).ToList();
        }

        public EmployeeDto GetEmployee(int id)
        {
            var e = _ctx.People.FirstOrDefault(p => p.PersonId == id);
            return (e == null) ? null : new EmployeeDto()
            {
                EmployeeId = e.PersonId,
                FirstName = e.FirstName,
                LastName = e.LastName
            };
        }

        public EmployeeBenefitElectionsDto GetEmployeeElections(int id)
        {
            var ebes = _ctx.BenefitElections.FirstOrDefault(b => b.PersonId == id);
            if (ebes == null)
            {
                return null;
            }
            var dto = new EmployeeBenefitElectionsDto()
            {
                Employee = new EmployeeDto()
                {
                    EmployeeId = ebes.PersonId,
                    FirstName = ebes.Person.FirstName,
                    LastName = ebes.Person.LastName
                },
                Elections = ebes.Dependents.Select(d => new BenefitElectionDto()
                {
                    Cost = new CostDto()
                    {
                        Amount = d.BenefitType.Cost,
                        BenefitRecipientTypeId = d.BenefitTypeId,
                        BenefitRecipientTypeName = d.BenefitType.Label
                    },
                    Person = new PersonDto()
                    {
                        PersonId = d.Person.PersonId,
                        FirstName = d.Person.FirstName,
                        LastName = d.Person.LastName,
                        RelationId = d.Person.RelationId
                    }
                }).ToList()
            };
            return dto;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employees = _ctx.People.Where(p => p.IsEmployee).ToList();
            var emps = employees.Select(e => new EmployeeDto()
            {
                EmployeeId = e.PersonId,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList();
            return emps;
        }

        public MetaDto GetMetaData()
        {
            var mta = _ctx.Meta.FirstOrDefault();
            var dto = mta == null ? new MetaDto()
            {
                BasePay = 2000m,
                PayPeriods = 26
            } : new MetaDto()
            {
                BasePay = mta.Salary,
                PayPeriods = mta.Weeks,
            };

            var costs = _ctx.BenefitRecipientTypes.ToList();
            if (costs.Any())
            {
                dto.Costs = costs.Select(c => new CostDto()
                {
                    Amount = c.Cost,
                    BenefitRecipientTypeId = c.BenefitRecipientTypeId,
                    BenefitRecipientTypeName = c.Label
                }).ToList();
            }
            else
            {
                dto.Costs = new List<CostDto>()
                {
                    new CostDto()
                    {
                        Amount = 1000m,
                        BenefitRecipientTypeId = 1,
                        BenefitRecipientTypeName = "Employee"
                    },
                    new CostDto()
                    {
                        Amount = 500m,
                        BenefitRecipientTypeId = 2,
                        BenefitRecipientTypeName = "Dependent"
                    }
                };
            }

            var disc = _ctx.Discounts.ToList();
            if (disc.Any())
            {
                dto.Discounts = disc.Select(d => new DiscountDto()
                {
                    DiscountAmount = d.DiscountAmount,
                    DiscountCriteria = d.Condition,
                    DiscountName = d.DiscountName,
                    DiscountFormula = d.Expression
                }).ToList();
            }
            else
            {
                dto.Discounts = new List<DiscountDto>()
                {
                    new DiscountDto()
                    {
                        DiscountAmount = 0.1m,
                        DiscountCriteria = "A",
                        DiscountName = "Name begins with A",
                        DiscountFormula = "{cost} - ({cost} * .1"
                    }
                };
            }
            
            return dto;
        }

        public bool Save()
        {
            return (_ctx.SaveChanges() >= 0);
        }
    }
}
