var numbers = Enumerable.Range(1, 1000000);

var parallelResult = numbers.AsParallel()
	.Where(n => n % 2 == 0)
	.Select(n => n * n)
	.ToList();

Console.WriteLine($"Processed {parallelResult.Count} even numbers in parallel.");