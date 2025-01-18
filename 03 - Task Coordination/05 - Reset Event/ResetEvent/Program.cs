await ProcessWithResetEventAsync();

static async Task ProcessWithResetEventAsync()
{
	// Starts in "unsignaled" state
	var manualResetEvent = new ManualResetEventSlim();

	var task1 = Task.Run(async () =>
	{
		await TaskOne();
		manualResetEvent.Set(); // Signal that task 1 is complete
	});

	manualResetEvent.Wait();
	await TaskTwo();
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