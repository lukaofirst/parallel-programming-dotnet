using System.Collections.Concurrent;

var csvFileName = "LargeFile.csv";
var csvFilePath = Path.Combine("Files", csvFileName);
var lines = await File.ReadAllLinesAsync(csvFilePath);
var results = new ConcurrentBag<string>();

var rangePartitioner = Partitioner.Create(0, lines.Length, 10);

var ranges = rangePartitioner.GetDynamicPartitions()
	.Select(range => (range.Item1, range.Item2));

await Parallel.ForEachAsync(ranges, async (range, cancellationToken) =>
{
	for (var i = range.Item1; i < range.Item2; i++)
	{
		var line = lines[i];

		if (line.Contains("Lorem"))
		{
			await Task.Delay(1000, cancellationToken);
			results.Add(line);
		}
	}

	Console.WriteLine($"Processed range {range.Item1}-{range.Item2}");
});

Console.WriteLine($"Found {results.Count} matches.");