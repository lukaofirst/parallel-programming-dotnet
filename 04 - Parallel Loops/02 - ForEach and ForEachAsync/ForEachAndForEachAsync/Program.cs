using System.Collections.Concurrent;

var filePaths = Directory.GetFiles("Logs", "*.txt");

/* --- Parallel.ForEach --- */

var lineCountsForEach = new ConcurrentDictionary<string, int>();

Parallel.ForEach(filePaths, filePath =>
{
	var lineCount = File.ReadLines(filePath).Count();
	lineCountsForEach[filePath] = lineCount;
	Console.WriteLine($"Processed {filePath}, Lines: {lineCount}");
});

foreach (var result in lineCountsForEach)
{
	Console.WriteLine($"File: {result.Key}, Lines: {result.Value}");
}

/* --- Parallel.ForEachAsync --- */

var lineCountsForEachAsync = new ConcurrentDictionary<string, int>();

await Parallel.ForEachAsync(filePaths, async (filePath, cancellationToken) =>
{
	var lineCount = 0;
	await foreach (var line in File.ReadLinesAsync(filePath, cancellationToken))
	{
		lineCount++;
	}
	lineCountsForEachAsync[filePath] = lineCount;
	Console.WriteLine($"Async - Processed {filePath}, Lines: {lineCount}");
});

foreach (var result in lineCountsForEachAsync)
{
	Console.WriteLine($"Async - File: {result.Key}, Lines: {result.Value}");
}