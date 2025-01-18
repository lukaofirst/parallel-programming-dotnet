using System.Collections.Concurrent;

var filePaths = Directory.GetFiles("Logs", "*.txt");

/* --- Parallel.For --- */

var lineCountsFor = new ConcurrentDictionary<string, int>();

Parallel.For(0, filePaths.Length, i =>
{
	var filePath = filePaths[i];
	var lineCount = File.ReadLines(filePath).Count();
	lineCountsFor[filePath] = lineCount;
	Console.WriteLine($"Processed {filePath}, Lines: {lineCount}");
});

foreach (var result in lineCountsFor)
{
	Console.WriteLine($"File: {result.Key}, Lines: {result.Value}");
}

/* --- Parallel.ForAsync --- */

var lineCountsForAsync = new ConcurrentDictionary<string, int>();

await Parallel.ForAsync(0, filePaths.Length, async (i, cancellationToken) =>
{
	var filePath = filePaths[i];

	var lineCount = 0;
	await foreach (var line in File.ReadLinesAsync(filePath, cancellationToken))
	{
		lineCount++;
	}
	lineCountsForAsync[filePath] = lineCount;
	Console.WriteLine($"Async - Processed {filePath}, Lines: {lineCount}");
});

foreach (var result in lineCountsForAsync)
{
	Console.WriteLine($"Async - File: {result.Key}, Lines: {result.Value}");
}