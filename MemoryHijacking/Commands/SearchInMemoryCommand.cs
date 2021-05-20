using System.ComponentModel;
using Spectre.Console.Cli;

namespace MemoryHijacking.Commands
{
	public class SearchInMemoryCommand : Command<SearchInMemoryCommand.Settings>
	{
		public class Settings : CommandSettings
		{
			[Description("value you want to search")]
			[CommandArgument(0, "[value]")]
			public int Value { get; init; }
		}

		public override int Execute(CommandContext context, Settings settings)
		{

			return 0;
		}
	}
}
