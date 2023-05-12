using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.Core.Entities;

public class Department:IEntity
{
    private static int _id;
    public int Id { get; }
    public string DepartmentName { get; set; }
    public int  EmployeeLimit { get; }
    public int CompanyId { get; set; }

    public Department()
    {
        Id = _id;
        _id++;
    }

    public override string ToString()
    {
        return $"Id: {Id} Department Name: {DepartmentName}";
    }
}

