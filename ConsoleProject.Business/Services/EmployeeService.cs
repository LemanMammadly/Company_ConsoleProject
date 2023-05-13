using System.Text.RegularExpressions;
using System.Xml.Linq;
using ConsoleProject.Business.Exceptions;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Interfaces;
using ConsoleProject.DataAccess.Implementations;

namespace ConsoleProject.Business.Services;

public class EmployeeService : IEmployeeInterface
{
    public EmployeeRepository employeeRepository { get; }

    public EmployeeService()
    {
        employeeRepository = new EmployeeRepository();
    }

    //public void Create(string name, string surname, decimal salary)
    //{
    //    string Trimname = name.Trim();
    //    string TrimSurname = surname.Trim();
    //    if (Trimname.Length < 2)
    //    {
    //        throw new SizeExceptions(Helper.Errors["SizeExceptions"]);
    //    }
    //    if(!Trimname.IsOnlyLetters())
    //    {
    //        throw new PatternDoesNotMatchException(Helper.Errors["PatternDoesNotMatchException"]);
    //    }
    //    if(!string.IsNullOrWhiteSpace(TrimSurname))
    //    {
    //        if(!TrimSurname.IsOnlyLetters())
    //        {
    //            throw new PatternDoesNotMatchException(Helper.Errors["PatternDoesNotMatchException"]);
    //        }
    //    }
    //    if(salary<=0)
    //    {
    //        throw new CannotBeLessThanZeroException(Helper.Errors["CannotBeLessThanZeroException"]);
    //    }
    //    Employee employee = new Employee(name, surname, salary);
    //    employeeRepository.Add(employee);
    //}

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetAll()
    {
        throw new NotImplementedException();
    }

    public Employee GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int employeeId, string name, string surname, decimal salary, int departmentId)
    {
        throw new NotImplementedException();
    }

    public void Create(Employee employee)
    {
        string TrimName=employee.Name.Trim();
        string TrimSurname=employee.Surname.Trim();
        if (TrimName.Length < 2)
        {
            throw new SizeExceptions(Helper.Errors["SizeExceptions"]);
        }
        if (!TrimName.IsOnlyLetters())
        {
            throw new PatternDoesNotMatchException(Helper.Errors["PatternDoesNotMatchException"]);
        }
        if (!string.IsNullOrWhiteSpace(TrimSurname))
        {
            if (!TrimSurname.IsOnlyLetters())
            {
                throw new PatternDoesNotMatchException(Helper.Errors["PatternDoesNotMatchException"]);
            }
        }
        if (employee.Salary <= 0)
        {
            throw new CannotBeLessThanZeroException(Helper.Errors["CannotBeLessThanZeroException"]);
        }
        employeeRepository.Add(employee);
    }
}

