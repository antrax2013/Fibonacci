
using Fibonacci;
using System.Diagnostics;

UInt128 index = 100_000;

Console.WriteLine($"Get Fibonacci {index}th term start...");
Stopwatch watcher = new();
watcher.Start();
//UStringNumber result = Fibonacci.Fibonacci.Generate(index);
UStringNumber result = Fibonacci.Fibonacci.GetValue(index);
watcher.Stop();

Console.WriteLine($"Fibonacci {index}th = {result}");
Console.WriteLine($"");

if (watcher.ElapsedMilliseconds > 10000)
    Console.WriteLine($"Elapsed time {((double)watcher.ElapsedMilliseconds / 1000)} s");
else
    Console.WriteLine($"Elapsed time {watcher.ElapsedMilliseconds} ms");

