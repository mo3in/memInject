using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryHijacking
{
	public static class Extensions
	{
		public static IEnumerable<string> Chunk(this string str, int chunkSize)
		{
			return Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
		}

		public static int CountSubStrings(this string input, string delimiter, bool ignoreCase = false)
		{
			var instancesNo = 0;
			var pos = 0;

			var invar = ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;
			while ((pos = input.IndexOf(delimiter, pos, invar)) != -1)
			{
				pos += delimiter.Length;
				instancesNo++;
			}

			return instancesNo;
		}

		public static string TxtQResult<T>(this T[] items) =>
			"Results: ".AsColor(StateColor.Success) + (items.Length > 0 ? items.Length.Parentheses() : Txt.NotFound.Parentheses());
	}
}
