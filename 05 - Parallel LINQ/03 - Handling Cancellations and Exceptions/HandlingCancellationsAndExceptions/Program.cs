var numbers = Enumerable.Range(1, 100000);
var cts = new CancellationTokenSource();

try
{
	var query = numbers.AsParallel()
		.WithCancellation(cts.Token)
		.Where(n =>
		{
			if (n == 50000)
			{
				cts.Cancel();
				//throw new Exception("Something wrong occured");
			}
			return n % 2 == 0;
		})
		.ToList();

	Console.WriteLine("Query completed.");
}
catch (OperationCanceledException)
{
	Console.WriteLine("Query was canceled.");
}
catch (AggregateException ex)
{
	Console.WriteLine($"Exceptions: {string.Join(", ", ex.InnerExceptions.Select(e => e.Message))}");
}