await ProcessWithCountdownEventAsync();

static async Task ProcessWithCountdownEventAsync()
{
	// Two signals needed to proceed
	var countdown = new CountdownEvent(2);

	var task1 = Task.Run(async () =>
	{
		await TaskOne();
		countdown.Signal(); // Notify that task 1 is complete
	});

	var task2 = Task.Run(async () =>
	{
		await TaskTwo();
		countdown.Signal(); // Notify that task 2 is complete
	});

	await Task.WhenAll(task1, task2);
	countdown.Wait();  // Wait until both tasks signal completion
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