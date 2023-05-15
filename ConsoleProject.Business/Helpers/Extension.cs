using System.Text.RegularExpressions;

namespace ConsoleProject.Business.Helpers;

public static class Extension
{
	public static bool IsOnlyLetters(this string value)
	{
		return Regex.IsMatch(value, @"^[a-zA-Z]+$");
	}

}

