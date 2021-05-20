using System.Collections.Generic;
using Spectre.Console;

namespace MemoryHijacking.Internal.Console
{
	public class Prompt
	{
		public static T Choose<T>(IEnumerable<T> items, string title)
		{
			var selection = new SelectionPrompt<T>()
				.Title(title)
				.PageSize(10)
				.AddChoices(items);

			return AnsiConsole.Prompt(selection);
		}
	}
}
