namespace ConsoleProject.Business.Helpers;

public static class Helper
{
    public static Dictionary<string, string> Errors = new Dictionary<string, string>()
    {
        {"SizeExceptions", "Length doesn't match"},
        {"AlreadyExistException","This object already exists" },
        {"ObjectNotFoundException","Object is not found" }
    };
}

