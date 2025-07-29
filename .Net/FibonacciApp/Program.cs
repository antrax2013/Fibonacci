
using Fibonacci;
using Fibonacci.Calculators;
using System.Diagnostics;

UInt128 index = 50_000;

Console.WriteLine($"Get Fibonacci {index}th term start...");

Task USYieldLoop = new(() =>
{
    Stopwatch watcher = new();
    watcher.Start();
    UStringNumber result = USYieldLoopFibonacciCalculator.GetValue(index);
    watcher.Stop();

    Console.WriteLine($"Fibonacci USYieldLoop {index}th = {result}");
    Console.WriteLine($"");

    if (watcher.ElapsedMilliseconds > 10000)
        Console.WriteLine($"Elapsed time {((double)watcher.ElapsedMilliseconds / 1000)} s");
    else
        Console.WriteLine($"Elapsed time {watcher.ElapsedMilliseconds} ms");
});

Task Matrix = new(() =>
{
    Stopwatch watcher = new();
    watcher.Start();
    UStringNumber result = MatrixFibonacciCalulator.GetValue(index);
    watcher.Stop();

    Console.WriteLine($"Fibonacci Matrix {index}th = {result}");
    Console.WriteLine($"");

    if (watcher.ElapsedMilliseconds > 10000)
        Console.WriteLine($"Elapsed time {((double)watcher.ElapsedMilliseconds / 1000)} s");
    else
        Console.WriteLine($"Elapsed time {watcher.ElapsedMilliseconds} ms");
});

USYieldLoop.Start();
Matrix.Start();

Task.WaitAll([USYieldLoop, Matrix]);



