public static class TaskSample
{
	public static async Task Execute()
	{
		var cts = new CancellationTokenSource();

		// Create a task
		Task<int> task = Task.Run(() =>
		{
			// some work
			Thread.Sleep(2000);
			return 42;
		}, cts.Token);

		// Cancel the task if needed
		// cts.Cancel();

		// Await the task and check properties
		try
		{
			int result = await task;
			Console.WriteLine($"Task completed successfully with result: {result}");
		}
		catch (AggregateException ex)
		{
			Console.WriteLine("Task failed with exceptions:");
			foreach (var innerEx in ex.InnerExceptions)
			{
				Console.WriteLine(innerEx.Message);
			}
		}
		finally
		{
			Console.WriteLine($"Task Status: {task.Status}");
			Console.WriteLine($"Is Faulted: {task.IsFaulted}");
			Console.WriteLine($"Is Canceled: {task.IsCanceled}");
		}
	}
}