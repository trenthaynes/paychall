using PayChall.API.Dtos;
using System.Collections.Generic;

namespace PayChall.API.Repository
{
    public interface IBenefitsRepository
    {
        MetaDto GetMetaData();
        IEnumerable<CostDto> GetCosts();
        IEnumerable<DiscountDto> GetDiscounts();
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployee(int id);
        bool Save();
        EmployeeBenefitElectionsDto GetEmployeeElections(int id);
        bool EmployeeExists(int id);
        EmployeeBenefitElectionsDto AddElections(int id, BenefitElectionsForCreateDto elections);
    }
}