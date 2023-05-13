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
        Thread.Sleep(1000);
        Company company = new Company(name);
        company.creationTime = DateTime.Now;
        companyRepository.Add(company);

    }

    public void Delete(int id)
    {
        var exits = companyRepository.Get(id);
        if(exits != null)
        {
            companyRepository.Delete(id);
            //if(departmentRepository.GetCompaniesId(id)==null)
            //{
            //    companyRepository.Delete(id);
            //}
            //else
            //{
            //    throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
            //}
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
        if(name.Length<=0)
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
}

