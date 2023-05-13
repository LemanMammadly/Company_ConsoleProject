using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface ICompanyInterface
{
    void Create(string companyName);
    void Delete(int id);
    void Update(string companyName,string newCompanyName);
    Company GetById(int id);
    List<Company> GetAll();
    List<Department> GetAllDepartment(string companyName);
}

