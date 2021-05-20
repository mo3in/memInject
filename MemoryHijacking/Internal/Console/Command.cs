namespace MemoryHijacking.Internal.Console
{
	public record Command(int Id, string Title)
	{
		public override string ToString() => $"{Id}- {Title}";
	}
}
