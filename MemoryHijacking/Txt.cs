namespace MemoryHijacking
{
	public static class Txt
	{
		// todo: maybe need some helper for color
		// public static readonly string SorryWarning = "[[Sorry]]".AsColor(ConsoleColor.Yellow);

		public static readonly string NotFound = "Not Found";
		public static readonly string Sorry = "Sorry";
		public static readonly string TryAgain = "Try again ...";
		public static readonly string CantFind = "we cant find your result";
		public static readonly string SelectProcessId = "select process id:";
		public static readonly string TotalCount = "total count";


		public static readonly string SorryCantFind = Sorry + ", " + CantFind;
		public static readonly string SorryCantFindTryAgain = Sorry + ", " + CantFind + ". " + TryAgain;
	}
}
