Parallel.Invoke(
	LoadDataFromDatabase,
	GenerateReport,
	SendEmailNotifications
);

Console.WriteLine("All tasks completed!");

static void LoadDataFromDatabase()
{
	Console.WriteLine("Loading data from the database...");
	Thread.Sleep(2000);
	Console.WriteLine("Database loading completed.");
}

static void GenerateReport()
{
	Console.WriteLine("Generating report...");
	Thread.Sleep(3000);
	Console.WriteLine("Report generation completed.");
}

static void SendEmailNotifications()
{
	Console.WriteLine("Sending email notifications...");
	Thread.Sleep(1500);
	Console.WriteLine("Email notifications sent.");
}
