namespace ConsoleProject.Business.Exceptions;

public class EmployeeHasDepartmentIdException:Exception
{
	public EmployeeHasDepartmentIdException(string message) : base(message) { }
}

