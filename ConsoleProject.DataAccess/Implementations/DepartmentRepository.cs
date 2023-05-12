using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Contexts;
using ConsoleProject.DataAccess.Interfaces;

namespace ConsoleProject.DataAccess.Implementations;

public class DepartmentRepository : IRepository<Department>
{
    public void Add(Department entity)
    {
        DbContext.Departments.Add(entity);
    }

    public void Delete(Department entity)
    {
        DbContext.Departments.Remove(entity);
    }

    public void Update(Department entity)
    {
        Department department=DbContext.Departments.Find(d=>d.Id==entity.Id);
        department.DepartmentName = entity.DepartmentName;
        department.EmployeeLimit = entity.EmployeeLimit;
        department.CompanyId = entity.CompanyId;
    }

    public Department? Get(int id)
    {
        return DbContext.Departments.Find(d => d.Id == id);
    }

    public List<Department> GetAll()
    {
        return DbContext.Departments;
    }
}

