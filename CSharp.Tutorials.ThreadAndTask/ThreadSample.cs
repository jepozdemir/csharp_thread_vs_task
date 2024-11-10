public static class ThreadSample
{
	public static void Execute()
	{
		// Unstarted state
		Thread thread = new Thread(ThreadMethod);

		thread.IsBackground = true;
		thread.Name = "MyThread";
		thread.Priority = ThreadPriority.AboveNormal;

		// Start the thread (Transition to Running state)
		thread.Start();

		if (thread.IsAlive)
		{
			Console.WriteLine("The thread is still running.");
		}

		// Wait for the thread to finish (join it)
		thread.Join(); // Now the thread is in Stopped state
	}

	private static void ThreadMethod()
	{
		Console.WriteLine("Thread is running...");

		// some work
		for (int i = 0; i < 3; i++)
		{
			Console.WriteLine($"Working... {i + 1}");
			Thread.Sleep(1000); // Thread enters WaitSleepJoin state
		}

		Console.WriteLine("Going to block...");

		// Blocking this thread
		object lockObject = new object();
		lock (lockObject)
		{
			Console.WriteLine("Thread is in critical section.");
			Thread.Sleep(1000);
		} // Thread exits critical section, transitioning back to Running

		Console.WriteLine("Work completed. Thread is stopping...");
	}
}