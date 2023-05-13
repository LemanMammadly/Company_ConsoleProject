namespace ConsoleProject.Business.Exceptions;

public class LimitDoesNotMatchException:Exception
{
	public LimitDoesNotMatchException(string message):base(message) { }
}

