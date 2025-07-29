namespace Fibonacci.API;

public interface IFibonacciCalculator<T>
{
    static abstract T GetValue(UInt128 index);
}
