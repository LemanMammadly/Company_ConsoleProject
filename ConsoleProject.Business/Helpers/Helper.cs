namespace ConsoleProject.Business.Helpers;

public static class Helper
{
    public static Dictionary<string, string> Errors = new Dictionary<string, string>()
    {
        {"SizeExceptions", "Length doesn't match"},
        {"AlreadyExistException","This object already exists" },
        {"ObjectNotFoundException","Object is not found" },
        {"SameNameException","Object with this name is already exits" },
        {"LimitDoesNotMatchException","Limit does not match" },
        {"ObjectDoesNotEmpty","Object does not empty" },
        {"PatternDoesNotMatchException","Pattern does not match" },
        {"CannotBeLessThanZeroException","Cannot be less than zero" }
    };
}

