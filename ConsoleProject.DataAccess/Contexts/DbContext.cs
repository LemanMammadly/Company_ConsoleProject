using ConsoleProject.Core.Entities;

namespace ConsoleProject.DataAccess.Contexts;

public static class DbContext
{
    public static List<Company> Companies { get; set; } = new();
    public static List<Department> Departments { get; set; } = new();
    public static List<Employee> Employees { get; set; } = new();
}

