using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface IDepartmentInterface
{
    void CreateDepartment(string departmentName, int limit, int companyId);
    void DeleteDepartment(int id);
    void UpdateDepartment(string departmentName, string newDepartmentName,int newLimit);
    Department GetByIdDepartment(int id);
    List<Department> GetAllDepartments();
    void AddEmployee(Employee employee,int departmentId);
    List<Employee> GetDepartmentEmployees(string departmentName);
}

