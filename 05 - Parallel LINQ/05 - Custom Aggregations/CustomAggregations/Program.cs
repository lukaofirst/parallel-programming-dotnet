var numbers = Enumerable.Range(1, 3);

var sumOfSquares = numbers.AsParallel().Aggregate(
	seed: 0,
	func: (subtotal, item) => subtotal + item * item, // Thread-local computation
	resultSelector: total => total // Final aggregation
);

Console.WriteLine($"Sum of squares: {sumOfSquares}");