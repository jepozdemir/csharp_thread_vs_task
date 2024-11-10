class Program
{
	static async Task Main()
	{
		Console.WriteLine("Thread sample :\r\n");
		ThreadSample.Execute();
		Console.WriteLine("\r\nTask sample :\r\n");
		await TaskSample.Execute();
	}
}
