using System.Collections.Concurrent;

namespace StackAndConcurrentStack;

public class ConcurrentStackImpl
{
	public static async Task Run()
	{
		var concurrentStack = new ConcurrentStack<int>();

		var tasks = new List<Task>
		{
			Task.Run(() =>
			{
				for (var i = 0; i < 10000; i++)
				{
					concurrentStack.Push(1);
				}
			}),
			Task.Run(() =>
			{
				for (var i = 0; i < 10000; i++)
				{
					concurrentStack.Push(2);
				}
			})
		};

		await Task.WhenAll(tasks);

		var sum = 0;
		while (concurrentStack.TryPop(out var item))
		{
			sum += item;
		}

		Console.WriteLine($"{nameof(ConcurrentStackImpl)} - Sum of all items in the stack: {sum}");
	}
}
