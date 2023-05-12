using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface ICompanyInterface
{
    void Create(string companyName);
    void Delete(int id);
    void Update(int id);
    Company GetById(int id);
    List<Company> GetAll();
}

