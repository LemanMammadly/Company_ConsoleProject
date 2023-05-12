namespace ConsoleProject.Business.Exceptions;

public class SameNameException:Exception
{
	public SameNameException(string message):base(message) { }
}

