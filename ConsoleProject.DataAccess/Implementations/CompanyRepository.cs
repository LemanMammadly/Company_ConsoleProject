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

    public void Delete(Company entity)
    {
        DbContext.Companies.Remove(entity);
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

    public List<Company> GetAll()
    {
        return DbContext.Companies;
    }

}

