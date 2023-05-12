using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.Core.Entities;

public class Company:IEntity
{
    private static int _id;
    public int Id { get; }
    public string CompanyName { get; set; }

    public Company()
    {
        Id = _id;
        _id++;
    }

    public Company(string companyName):this()
    {
        CompanyName = companyName;
    }
}

