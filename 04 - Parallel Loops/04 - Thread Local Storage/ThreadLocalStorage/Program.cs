using System.Collections.Concurrent;

var urls = new[]
{
	"https://jsonplaceholder.typicode.com/posts/1",
	"https://jsonplaceholder.typicode.com/posts/2",
	"https://jsonplaceholder.typicode.com/posts/3"
};

var results = new ConcurrentBag<string>();

Parallel.ForEach(
	urls,
	// Thread-local initializer: Creates an HttpClient for each thread
	() => new HttpClient(),
	// Body: Uses the thread-local HttpClient to fetch data
	(url, state, client) =>
	{
		try
		{
			var result = client.GetStringAsync(url).Result; // Fetch the data
			results.Add(result); // Store the result in a thread-safe collection
			Console.WriteLine($"Fetched {url}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error fetching {url}: {ex.Message}");
		}

		return client; // Return the thread-local HttpClient
	},
	// Finalizer: Dispose of the thread-local HttpClient
	client => client.Dispose()
);

Console.WriteLine("\nFetched Results:");
foreach (var result in results)
{
	Console.WriteLine(result);
}