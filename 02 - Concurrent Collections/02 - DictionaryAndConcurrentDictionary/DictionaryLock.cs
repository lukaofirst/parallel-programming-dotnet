namespace DictionaryAndConcurrentDictionary;

public static class DictionaryLock
{
	public static async Task Run()
	{
		var dictionary = new Dictionary<int, string>();
		var lockObj = new Lock();

		var tasks = new List<Task>
		{
			Task.Run(() => {
				lock (lockObj)
				{
					for (var i = 0; i < 10000; i++)
					{
						dictionary.Add(i, $"Task1 {i}");
						// to simulate race condition, comment the lock's block and enable this
						// Task.Delay(1).Wait();
					}
				}
			}),
			Task.Run(() => {
				lock (lockObj)
				{
					for (var i = 10000; i < 20000; i++)
					{
						dictionary.Add(i, $"Task2 {i}");
						// to simulate race condition, comment the lock's block and enable this
					    // Task.Delay(1).Wait();
					}
				}
			})
		};

		await Task.WhenAll(tasks);

		Console.WriteLine($"{nameof(DictionaryLock)} - Dictionary count: {dictionary.Count}");
		Console.WriteLine($"{nameof(DictionaryLock)} - Dictionary sum: {dictionary.Sum(x => x.Key)}");
	}
}
