using ConsoleProject.Business.Exceptions;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Interfaces;
using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Implementations;

namespace ConsoleProject.Business.Services;

public class DepartmentService : IDepartmentInterface
{
    public DepartmentRepository departmentRepository { get;}
    public CompanyRepository companyRepository { get; }
    public EmployeeRepository employeeRepository { get;}

    public DepartmentService()
    {
        departmentRepository = new DepartmentRepository();
        companyRepository = new CompanyRepository();
        employeeRepository = new EmployeeRepository();
    }

    public void Create(string departmentName, int limit, int companyId)
    {
        var exists = departmentRepository.GetByName(departmentName);
        var companyExits = companyRepository.Get(companyId);
        if(companyExits == null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        if (exists != null) 
        {
            throw new AlreadyExistException(Helper.Errors["AlreadyExistException"]);
        }
        string name = departmentName.Trim();
        if (name.Length <= 0)
        {
            throw new SizeExceptions(Helper.Errors["SizeExceptions"]);
        }
        if(limit<=0)
        {
            throw new LimitDoesNotMatchException(Helper.Errors["LimitDoesNotMatchException"]);
        }
        Department department = new Department(name, limit, companyId);
        departmentRepository.Add(department);
    }

    public void Delete(int id)
    {
        var exists = departmentRepository.Get(id);
        if(exists != null)
        {
            departmentRepository.Delete(id);
            if (employeeRepository.GetAlDepartmentId(id).Count == 0)
            {
                departmentRepository.Delete(id);
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

    public void Update(string departmentName, string newDepartmentName, int newLimit)
    {
        throw new NotImplementedException();
    }

    public List<Department> GetAll()
    {
        return departmentRepository.GetAll();
    }

    public Department GetById(int id)
    {
        var exists = departmentRepository.Get(id);
        if(exists==null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        return exists;
    }

    public void AddEmployee(Employee employee)
    {
        var existId = employeeRepository.Get(employee.DepartmentId);
        if (existId == null) 
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        existId.DepartmentId = employee.DepartmentId;
    }

    public List<Employee> GetDepartmentEmployees(string departmentName)
    {
        throw new NotImplementedException();
    }

}

