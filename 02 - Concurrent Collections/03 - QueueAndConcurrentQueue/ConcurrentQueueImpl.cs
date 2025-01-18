using System.Collections.Concurrent;

namespace QueueAndConcurrentQueue;

public class ConcurrentQueueImpl
{
	public static async Task Run()
	{
		var concurrentQueue = new ConcurrentQueue<int>();

		var tasks = new List<Task>
		{
			Task.Run(() =>
			{
				for (var i = 0; i < 10000; i++)
				{
					concurrentQueue.Enqueue(1);
				}
			}),
			Task.Run(() =>
			{
				for (var i = 0; i < 10000; i++)
				{
					concurrentQueue.Enqueue(2);
				}
			})
		};

		await Task.WhenAll(tasks);

		var sum = 0;
		while (concurrentQueue.TryDequeue(out var item))
		{
			sum += item;
		}

		Console.WriteLine($"{nameof(ConcurrentQueueImpl)} - Sum of all items in the queue: {sum}");
	}
}
