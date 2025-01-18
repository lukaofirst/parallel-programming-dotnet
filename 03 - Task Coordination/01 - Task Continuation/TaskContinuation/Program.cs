await ProcessWithContinuationsAsync();

static async Task ProcessWithContinuationsAsync()
{
	var task1 = TaskOne();
	await task1;
	await task1.ContinueWith(t => TaskTwo()).Unwrap();
	await task1.ContinueWith(t => TaskThree()).Unwrap();
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

static async Task TaskThree()
{
	await Task.Delay(3000);
	Console.WriteLine($"{nameof(TaskThree)} executed");
}