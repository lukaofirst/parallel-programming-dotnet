namespace QueueAndConcurrentQueue;

public static class QueueLock
{
	public static void Run()
	{
		var queue = new Queue<int>();
		var lockObj = new Lock();

		var tasks = new List<Task>
		{
			Task.Run(() =>
			{
				lock (lockObj)
				{
					for (var i = 0; i < 10000; i++)
					{
						queue.Enqueue(1);
						// to simulate race condition, comment the lock's block and enable this
						// Task.Delay(1).Wait();
					}
				}
			}),
			Task.Run(() =>
			{
				lock (lockObj)
				{
					for (var i = 0; i < 10000; i++)
					{
						queue.Enqueue(2);
						// to simulate race condition, comment the lock's block and enable this
						// Task.Delay(1).Wait();
					}
				}
			})
		};

		Task.WaitAll(tasks);

		var sum = 0;
		lock (lockObj)
		{
			while (queue.Count > 0)
			{
				sum += queue.Dequeue();
			}
		}

		Console.WriteLine($"{nameof(QueueLock)} - Sum of all items in the queue: {sum}");
	}
}
