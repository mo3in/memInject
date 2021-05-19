﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cocona;
using Memory;
using MemoryHijacking;
using Spectre.Console;

namespace MemoryHijacking
{
	class Program
	{
		private Mem _mem = new();

		private static Process[] _processes;

		static async Task Main(string[] args)
		{
			_processes = Process.GetProcesses();
			AnsiConsole.WriteLine("selecting process:");


			var processQ = AnsiConsole.Prompt(
				new TextPrompt<string>("[grey][[Optional]][/] search by app name/id").AllowEmpty()
			);

			int processId = -1;
			if (!string.IsNullOrWhiteSpace(processQ))
			{
				var results = FindProcessesByQuery(processQ);
				// AnsiConsole.MarkupLine(results.TxtQResult());

				if (results.Length == 0)
				{
					AnsiConsole.MarkupLine(Txt.SorryCantFindTryAgain.Parentheses().AsColor(StateColor.Warning));
				}
				else
				{
					var processName = AnsiConsole.Prompt(
						new SelectionPrompt<string>()
							.Title(Txt.SelectProcessId.AsColor(StateColor.Info))
							.MoreChoicesText(results.TxtTotalCount())
							.PageSize(10)
							.AddChoices(results.Select(x => x.ToString()))
					);

					var selected = results.FirstOrDefault(x =>
						x.Name.Equals(processName, StringComparison.OrdinalIgnoreCase)
					);

					if (selected != null)
					{
						processId = selected.Id;
					}
				}
			}


			// var fruit = AnsiConsole.Prompt(
			//     new SelectionPrompt<string>()
			//         .Title("What's your [green]favorite fruit[/]?")
			//         .PageSize(10)
			//         // .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
			//         .AddChoices(_processes.Select(x => ))
			// );

			// Console.WriteLine(fruit);
			// await CoconaLiteApp.RunAsync<Program>(args);
			// var mem = new Mem();
			//
			// var pId = mem.GetProcIdFromName("ConsoleApp1");
			//
			// if (!mem.OpenProcess(pId))
			// {
			//     Console.WriteLine("process not found");
			//     return;
			// }
			//
			// var memAddress = string.Empty;
			//
			// while (true)
			// {
			//     Console.Write("enter value for search [non-skipped]: ");
			//     var search = Console.ReadLine();
			//     if (!string.IsNullOrEmpty(search))
			//     {
			//         var hexValue = string.Join(' ', int.Parse(search).ToString("X").Chunk(2).Reverse());
			//         Console.WriteLine($"hex value: [{hexValue}]");
			//
			//         var result = await mem.AoBScan(0x00000000, 0x000007fffffffffff, hexValue, true);
			//
			//         Console.WriteLine($"total find: [{result.Count()}]");
			//
			//         foreach (var item in result)
			//         {
			//             Console.WriteLine($"address: {item:x8} : [{mem.ReadInt(item.ToString("x8"))}]");
			//             mem.WriteMemory(item.ToString("x8"), "int", "13999");
			//         }
			//     }
			//
			//     // Console.Write("enter value: ");
			//     // var number = int.Parse(Console.ReadLine());
			//     //
			//     // mem.WriteMemory("0x7FFE56A52C2C", "int", number.ToString());
			//     // mem.
			// }
		}

		private static ProcessQResult[] FindProcessesByQuery(string q)
		{
			return _processes.Where(x =>
				x.Id.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
				x.ProcessName.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
			).Select(x =>
				new ProcessQResult(x.Id, x.ProcessName, x.ProcessName.CountSubStrings(q, true), x.ProcessName.Length)
			).ToArray();
		}

		record ProcessQResult(int Id, string Name, int RepeatCount, int RepeatCountCharsLeft)
		{
			public override string ToString() => $"[[{Id.ToString().PadRight(7, ' ')}]]\t{Name}";

			public static implicit operator string(ProcessQResult result) => result.ToString();
		};

		[Command(Description = "find a application")]
		public void FindApp([Argument] string processName)
		{
			var pId = _mem.GetProcIdFromName("ConsoleApp1");

			if (!_mem.OpenProcess(pId))
			{
				Console.WriteLine("process not found");
			}
		}

		[Command(Description = "find value in memory")]
		public void FindValue(
			[Argument(Description = "process name")]
			string processName
		)
		{
			var pId = _mem.GetProcIdFromName("ConsoleApp1");

			if (!_mem.OpenProcess(pId))
			{
				Console.WriteLine("process not found");
			}
		}
	}
}