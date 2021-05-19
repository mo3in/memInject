using System;

namespace MemoryHijacking
{
	public static class TxtExtensions
	{
		public static string Parentheses(this string text) => $"[[{text}]]";
		public static string Parentheses(this int text) => Parentheses(text.ToString());

		public static string AsColor(this string text, ConsoleColor color) => $"[{color}]{text}[/]";

		public static string AsColor(this string text, StateColor stateColor)
		{
			return text.AsColor(stateColor.StateColorToConsoleColor());
		}

		public static string TotalCount(int count) => Txt.TotalCount + " " + count.Parentheses();


		public static string TxtTotalCount<T>(this T[] items) => TotalCount(items.Length);

		private static ConsoleColor StateColorToConsoleColor(this StateColor color) => color switch
		{
			StateColor.Success => ConsoleColor.Green,
			StateColor.Warning => ConsoleColor.Yellow,
			StateColor.Danger => ConsoleColor.Red,
			StateColor.Info => ConsoleColor.DarkCyan,
			_ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
		};
	}

	public enum StateColor
	{
		Success,
		Info,
		Warning,
		Danger
	}
}
