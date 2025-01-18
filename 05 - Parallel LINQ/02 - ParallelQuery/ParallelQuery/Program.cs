var numbers = Enumerable.Range(1, 10000);

ParallelQuery<int> parallelQuery = numbers.AsParallel()
	// .AsOrdered()
	.Where(n => n % 2 != 0);

foreach (var num in parallelQuery)
{
	Console.WriteLine(num);
}