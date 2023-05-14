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
        var exits = companyRepository.GetByName(companyName);
        var existsCompany = companyRepository.GetAll();
        if(name.Length<=0)
        {
            throw new SizeExceptions(Helper.Errors["SizeExceptions"]);
        }
        if(exits != null)
        {
            throw new AlreadyExistException(Helper.Errors["AlreadyExistException"]);
        }
        foreach (Company item in existsCompany)
        {
            if(item.CompanyName.ToUpper()==companyName.ToUpper())
            {
                throw new AlreadyExistException(Helper.Errors["AlreadyExistException"]);
            }
        }
        //Thread.Sleep(1000);
        Company company = new Company(companyName);
        company.creationTime = DateTime.Now;
        companyRepository.Add(company);

    }

    public void Delete(int id)
    {
        var exits = companyRepository.Get(id);
        if(exits != null)
        {
            if (departmentRepository.GetCompaniesId(id).Count==0)
            {
                companyRepository.Delete(id);
            }
            else
            {
                throw new ObjectDoesNotEmpty(Helper.Errors["ObjectDoesNotEmpty"]);
            }
        }
        else
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
    }

    public void Update(string companyName, string newCompanyName)
    {
        var exits = companyRepository.GetByName(companyName);
        string name = newCompanyName.Trim();
        var exitsNewname = companyRepository.GetByName(name);
        if(exitsNewname != null)
        {
            throw new AlreadyExistException(Helper.Errors["AlreadyExistException"]);
        }
        if (name.Length<=0)
        {
            throw new SizeExceptions(Helper.Errors["SizeExceptions"]);
        }
        if(exits == null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        if(exits.CompanyName.ToUpper()==newCompanyName.ToUpper())
        {
            throw new SameNameException(Helper.Errors["SameNameException"]);
        }
        exits.CompanyName = newCompanyName;
        companyRepository.Update(exits);
    }


    public List<Company> GetAll()
    {
        return companyRepository.GetAll();
    }

    public Company GetById(int id)
    {
        var exist = companyRepository.Get(id);
        if(exist==null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        return exist;
    }

    public List<Department> GetAllDepartment(string companyName)
    {
        var exists = companyRepository.GetByName(companyName);
        if (exists != null)
        {
            var exitsDepartment = departmentRepository.GetCompaniesId(exists.Id);
            if (exitsDepartment != null) 
            {
                return exitsDepartment;
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
}

