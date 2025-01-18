using System.Collections.Concurrent;

namespace ListAndConcurrentBag;

public static class ConcurrentBagImpl
{
	public static async Task Run()
	{
		var concurrentBag = new ConcurrentBag<int>();

		var tasks = new List<Task>
		{
			Task.Run(() => {
				for (var i = 0; i < 10000; i++)
				{
					concurrentBag.Add(1);
				}
			}),
			Task.Run(() => {
				for (var i = 0; i < 10000; i++)
				{
					concurrentBag.Add(2);
				}
			})
		};

		await Task.WhenAll(tasks);

		Console.WriteLine($"{nameof(ConcurrentBagImpl)} - List count: {concurrentBag.Count}");
		Console.WriteLine($"{nameof(ConcurrentBagImpl)} - List sum: {concurrentBag.Sum()}");
	}
}
