await ProcessWithSemaphoreAsync();

static async Task ProcessWithSemaphoreAsync()
{
	// Allow 2 concurrent tasks
	var semaphore = new SemaphoreSlim(2);

	var task1 = Task.Run(async () =>
	{
		await semaphore.WaitAsync();

		try
		{
			await TaskOne();
		}
		finally
		{
			semaphore.Release();
		}
	});

	var task2 = Task.Run(async () =>
	{
		await semaphore.WaitAsync();

		try
		{
			await TaskTwo();
		}
		finally
		{
			semaphore.Release();
		}
	});

	await Task.WhenAll(task1, task2);
}

static async Task TaskOne()
{
	await Task.Delay(1000);
	Console.WriteLine($"{nameof(TaskOne)} executed");
}

static async Task TaskTwo()
{
	await Task.Delay(2000);
	Console.WriteLine($"{nameof(TaskTwo)} executed");
}