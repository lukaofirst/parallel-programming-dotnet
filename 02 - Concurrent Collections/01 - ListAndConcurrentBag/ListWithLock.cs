namespace ListAndConcurrentBag;

public static class ListWithLock
{
	public static async Task Run()
	{
		var list = new List<int>();
		var lockObj = new Lock();

		var tasks = new List<Task>
		{
			Task.Run(() => {
				lock (lockObj)
				{
					for (var i = 0; i < 10000; i++)
					{
						list.Add(1);
						// to simulate race condition, comment the lock's block and enable this
						// Task.Delay(1).Wait();
					}
				}
			}),
			Task.Run(() => {
				lock (lockObj)
				{
					for (var i = 0; i < 10000; i++)
					{
						list.Add(2);
						// to simulate race condition, comment the lock's block and enable this
						// Task.Delay(1).Wait();
					}
				}
			})
		};

		await Task.WhenAll(tasks);

		Console.WriteLine($"{nameof(ListWithLock)} - List count: {list.Count}");
		Console.WriteLine($"{nameof(ListWithLock)} - List sum: {list.Sum()}");
	}
}
