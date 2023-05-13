using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface IEmployeeInterface
{
    void Create(string name, string surname, decimal salary, int departmentId);
    void Update(int employeeId, string name, string surname, decimal salary, int departmentId);
    void Delete(int id);
    Employee GetById(int id);
    List<Employee> GetAll();
}

