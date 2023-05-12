namespace ConsoleProject.Core.Entities;

public class Company
{
    private static int _id;
    public int Id { get; }
    public string CompanyName { get; set; }

    public Company()
    {
        Id = _id;
        _id++;
    }
}

