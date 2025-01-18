HandlingExceptionsParallelFor();
HandlingExceptionsParallelForEach();
await HandlingExceptionsParallelForAsync();
await HandlingExceptionsParallelForEachAsync();

static void HandlingExceptionsParallelFor()
{
	try
	{
		Parallel.For(0, 5, i =>
		{
			Console.WriteLine($"Parallel.For - Processing item {i}");
			if (i == 3)
				throw new InvalidOperationException($"Error processing item {i}");
		});
	}
	catch (AggregateException ex)
	{
		foreach (var inner in ex.InnerExceptions)
		{
			Console.WriteLine($"Parallel.For - Exception: {inner.Message}");
		}
	}
}

static void HandlingExceptionsParallelForEach()
{
	var items = new List<int> { 1, 2, 3, 4, 5 };

	try
	{
		Parallel.ForEach(items, item =>
		{
			Console.WriteLine($"Parallel.ForEach - Processing item {item}");
			if (item == 3)
				throw new InvalidOperationException($"Error processing item {item}");
		});
	}
	catch (AggregateException ex)
	{
		foreach (var inner in ex.InnerExceptions)
		{
			Console.WriteLine($"Parallel.ForEach - Exception: {inner.Message}");
		}
	}
}

static async Task HandlingExceptionsParallelForAsync()
{
	var exceptionsForAsync = new List<Exception>();

	try
	{
		await Parallel.ForAsync(0, 5, async (i, cancellationToken) =>
		{
			Console.WriteLine($"Parallel.ForAsync - Processing item {i}");
			if (i == 3)
				throw new InvalidOperationException($"Error processing item {i}");
			await Task.Delay(500, cancellationToken);
		});
	}
	catch (Exception ex)
	{
		lock (exceptionsForAsync)
		{
			exceptionsForAsync.Add(ex);
		}
	}

	if (exceptionsForAsync.Count is not 0)
	{
		Console.WriteLine("Parallel.ForAsync - Collected exceptions:");
		foreach (var ex in exceptionsForAsync)
		{
			Console.WriteLine($"Parallel.ForAsync - Exception: {ex.Message}");
		}
	}
}

static async Task HandlingExceptionsParallelForEachAsync()
{
	var items = new List<int> { 1, 2, 3, 4, 5 };
	var exceptions = new List<Exception>();

	try
	{
		await Parallel.ForEachAsync(items, async (item, cancellationToken) =>
		{
			Console.WriteLine($"Parallel.ForEachAsync - Processing item {item}");
			if (item == 3)
				throw new InvalidOperationException($"Error processing item {item}");
			await Task.Delay(500, cancellationToken);
		});
	}
	catch (Exception ex)
	{
		lock (exceptions)
		{
			exceptions.Add(ex);
		}
	}

	if (exceptions.Count is not 0)
	{
		Console.WriteLine("Parallel.ForEachAsync - Collected exceptions:");
		foreach (var ex in exceptions)
		{
			Console.WriteLine($"Parallel.ForEachAsync - Exception: {ex.Message}");
		}
	}
}