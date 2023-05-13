namespace ConsoleProject.Business.Exceptions;

public class CannotBeLessThanZeroException:Exception
{
	public CannotBeLessThanZeroException(string message) : base(message) { }
}

