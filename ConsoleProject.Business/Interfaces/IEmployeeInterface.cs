using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface IEmployeeInterface
{
    void CreateEmployee(Employee employee);
    void UpdateEmployee(int employeeId, string name, string surname, double salary, int departmentId);
    void DeleteEmployee(int id);
    Employee GetByIdEmployee(int id);
    List<Employee> GetAllEmployee();
}

