using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface IDepartmentInterface
{
    void Create(string departmentName, int limit, int companyId);
    void Delete(int id);
    void Update(string departmentName, string newDepartmentName,int newLimit);
    Department GetById(int id);
    List<Department> GetAll();
    void AddEmployee(Employee employee);
    List<Employee> GetDepartmentEmployees(string departmentName);
}

