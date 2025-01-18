namespace StackAndConcurrentStack;

public class StackLock
{
	public static async Task Run()
	{
		var stack = new Stack<int>();
		var lockObj = new Lock();

		var tasks = new List<Task>
		{
			Task.Run(() =>
			{
				lock (lockObj)
				{
					for (var i = 0; i < 10000; i++)
					{
						stack.Push(1);
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
						stack.Push(2);
						// to simulate race condition, comment the lock's block and enable this
						// Task.Delay(1).Wait();
					}
				}
			})
		};

		await Task.WhenAll(tasks);

		var sum = 0;
		lock (lockObj)
		{
			while (stack.Count > 0)
			{
				sum += stack.Pop();
			}
		}

		Console.WriteLine($"{nameof(StackLock)} - Sum of all items in the stack: {sum}");
	}
}
