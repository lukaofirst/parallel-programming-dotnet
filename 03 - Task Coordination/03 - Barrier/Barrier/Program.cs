await ProcessWithBarrierAsync();

static async Task ProcessWithBarrierAsync()
{
	// Two tasks must reach the barrier
	var barrier = new Barrier(2);

	var task1 = Task.Run(async () =>
	{
		await TaskOne();
		barrier.SignalAndWait(); // Notify the barrier
	});

	var task2 = Task.Run(async () =>
	{
		await TaskTwo();
		barrier.SignalAndWait(); // Notify the barrier
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