using ConsoleProject.Business.Exceptions;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Interfaces;
using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Implementations;

namespace ConsoleProject.Business.Services;

public class CompanyService : ICompanyInterface
{
    public CompanyRepository companyRepository { get;}
    public DepartmentRepository departmentRepository { get; }

    public CompanyService()
    {
        companyRepository = new CompanyRepository();
        departmentRepository = new DepartmentRepository();
    }

    public void Create(string companyName)
    {
        string name = companyName.Trim();
        if(name.Length<=0)
        {
            throw new SizeExceptions(Helper.Errors["SizeExceptions"]);
        }

        var exits = companyRepository.GetByName(name);
        if(exits != null)
        {
            throw new AlreadyExistException(Helper.Errors["AlreadyExistException"]);
        }
        Company company = new Company(name);
        companyRepository.Add(company);

    }

    public void Delete(int id)
    {
        var exits = companyRepository.Get(id);
        if(exits != null)
        {
            if(departmentRepository.GetCompaniesId(id)==null)
            {
                companyRepository.Delete(id);
            }
            else
            {
                throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
            }
        }
        else
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
    }

    public List<Company> GetAll()
    {
        throw new NotImplementedException();
    }

    public Company GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id)
    {
        throw new NotImplementedException();
    }
}

