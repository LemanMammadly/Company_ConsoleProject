using System.Collections.Generic;
using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Contexts;
using ConsoleProject.DataAccess.Interfaces;

namespace ConsoleProject.DataAccess.Implementations;

public class EmployeeRepository : IRepository<Employee>
{
    public void Add(Employee entity)
    {
        DbContext.Employees.Add(entity);
    }

    public void Delete(int id)
    {
        Employee employee = DbContext.Employees.Find(e => e.Id == id);
        DbContext.Employees.Remove(employee);
    }

    public void Update(Employee entity)
    {
        Employee employee= DbContext.Employees.Find(e=>e.Id==entity.Id);
        employee.Name = entity.Name;
        employee.Surname = entity.Surname;
        employee.Salary = entity.Salary;
        employee.DepartmentId = entity.DepartmentId;
    }

    public Employee? Get(int id)
    {
        return DbContext.Employees.Find(e=>e.Id==id);
    }

    public List<Employee> GetAlDepartmentId(int id)
    {
        return DbContext.Employees.FindAll(e => e.DepartmentId == id);
    }

    public List<Employee> GetAll()
    {
        return DbContext.Employees;
    }
}

