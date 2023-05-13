namespace ConsoleProject.Business.Exceptions;

public class PatternDoesNotMatchException:Exception
{
	public PatternDoesNotMatchException(string message) : base(message) { }
}

