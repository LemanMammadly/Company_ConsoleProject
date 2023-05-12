using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Contexts;
using ConsoleProject.DataAccess.Interfaces;

namespace ConsoleProject.DataAccess.Implementations;

public class CompanyRepository : IRepository<Company>
{
    public void Add(Company entity)
    {
        DbContext.Companies.Add(entity);
    }

    public void Delete(int id)
    {
        Company company = DbContext.Companies.Find(c => c.Id == id);
        DbContext.Companies.Remove(company);
    }

    public void Update(Company entity)
    {
        Company company = DbContext.Companies.Find(c => c.Id == entity.Id);
        company.CompanyName = entity.CompanyName;
    }

    public Company? Get(int id)
    {
        return DbContext.Companies.Find(c => c.Id == id);
    }

    public Company? GetByName(string name)
    {
        return DbContext.Companies.Find(c => c.CompanyName == name);
    }

    public List<Company> GetAll()
    {
        return DbContext.Companies;
    }

}

