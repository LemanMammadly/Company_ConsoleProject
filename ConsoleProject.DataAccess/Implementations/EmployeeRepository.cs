using System.Collections.Generic;
using ConsoleProject.DataAccess.Contexts;
using ConsoleProject.DataAccess.Interfaces;

namespace ConsoleProject.DataAccess.Implementations;

public class EmployeeRepository : IRepository<Employee>
{
    public void Add(Employee entity)
    {
        DbContext.Employees.Add(entity);
    }

    public void Delete(Employee entity)
    {
        DbContext.Employees.Remove(entity);
    }

    public void Update(Employee entity)
    {
        Employee employee= DbContext.Employees.Find(e=>e.Id==entity.Id);
        employee.Name = entity.Name;
        employee.Surname = entity.Surname;
        employee.Salary = entity.Salary;
    }

    public Employee? Get(int id)
    {
        return DbContext.Employees.Find(e=>e.Id==id);
    }

    public List<Employee> GetAll()
    {
        return DbContext.Employees;
    }

}

