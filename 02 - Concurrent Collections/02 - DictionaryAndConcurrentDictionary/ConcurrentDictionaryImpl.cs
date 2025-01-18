using System.Collections.Concurrent;

namespace DictionaryAndConcurrentDictionary;

public static class ConcurrentDictionaryImpl
{
	public static async Task Run()
	{
		var concurrentDictionary = new ConcurrentDictionary<int, string>();
		var lockObj = new Lock();

		var tasks = new List<Task>
		{
			Task.Run(() => {
				lock (lockObj)
				{
					for (var i = 0; i < 10000; i++)
					{
						concurrentDictionary[i] = $"Task1 {i}";
					}
				}
			}),
			Task.Run(() => {
				lock (lockObj)
				{
					for (var i = 10000; i < 20000; i++)
					{
						concurrentDictionary[i] = $"Task2 {i}";
					}
				}
			})
		};

		await Task.WhenAll(tasks);

		Console.WriteLine($"{nameof(ConcurrentDictionaryImpl)} - Dictionary count: {concurrentDictionary.Count}");
		Console.WriteLine($"{nameof(ConcurrentDictionaryImpl)} - Dictionary sum: {concurrentDictionary.Sum(x => x.Key)}");
	}
}
