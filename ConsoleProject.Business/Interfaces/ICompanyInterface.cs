using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface ICompanyInterface
{
    void CreateCompany(string companyName);
    void DeleteCompany(int id);
    void UpdateCompany(string companyName,string newCompanyName);
    Company GetByIdCompany(int id);
    List<Company> GetAllCompany();
    List<Department> GetAllDepartment(string companyName);
}

