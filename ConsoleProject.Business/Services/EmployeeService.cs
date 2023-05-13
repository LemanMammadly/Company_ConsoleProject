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
    public DepartmentRepository departmentRepository { get; }

    public EmployeeService()
    {
        employeeRepository = new EmployeeRepository();
        departmentRepository = new DepartmentRepository();
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

    public void Update(int employeeId, string name, string surname, decimal salary, int departmentId)
    {
        var existsEmployee = employeeRepository.Get(employeeId);
        var existsDepartmentId = departmentRepository.Get(departmentId);
        var nameTrim = name.Trim();
        var surnameTrim = surname.Trim();
        if(existsEmployee==null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        if(nameTrim.Length<2)
        {
            throw new SizeExceptions(Helper.Errors["SizeExceptions"]);
        }
        if(!nameTrim.IsOnlyLetters())
        {
            throw new PatternDoesNotMatchException(Helper.Errors["PatternDoesNotMatchException"]);
        }
        if (!string.IsNullOrWhiteSpace(surnameTrim))
        {
            if (!surnameTrim.IsOnlyLetters())
            {
                throw new PatternDoesNotMatchException(Helper.Errors["PatternDoesNotMatchException"]);
            }
        }
        if (salary <= 0)
        {
            throw new CannotBeLessThanZeroException(Helper.Errors["CannotBeLessThanZeroException"]);
        }
        if(existsDepartmentId==null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        existsEmployee.Name = name;
        existsEmployee.Surname = surname;
        existsEmployee.Salary = salary;
        existsEmployee.DepartmentId = departmentId;
        employeeRepository.Update(existsEmployee);
    }

    public void Delete(int id)
    {
        var existEmployee = employeeRepository.Get(id);
        if(existEmployee==null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        employeeRepository.Delete(id);
    }

    public List<Employee> GetAll()
    {
        return employeeRepository.GetAll();
    }

    public Employee GetById(int id)
    {
        var existEmployee = employeeRepository.Get(id);
        if(existEmployee==null)
        {
            throw new ObjectNotFoundException(Helper.Errors["ObjectNotFoundException"]);
        }
        return existEmployee;
    }
}

