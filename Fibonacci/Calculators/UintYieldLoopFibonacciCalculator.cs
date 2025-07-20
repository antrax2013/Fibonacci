using Fibonacci.API;

namespace Fibonacci.Calculators;

public class UintYieldLoopFibonacciCalculator : IFibonacciCalculator<UInt128>
{
    public static UInt128 GetValue(UInt128 index)
    {
        IEnumerable<UInt128> values = GenerateSequence(index);
        return values.Last();
    }

    private static IEnumerable<UInt128> GenerateSequence(UInt128 index)
    {
        yield return 0;
        if (index == 0) yield break;

        yield return 1;
        if (index == 1) yield break;

        yield return 1;
        if (index == 2) yield break;

        UInt128 next = 1;
        UInt128 prev = 1;
        for (UInt128 i = 2; i < index; i++)
        {
            UInt128 sum = next + prev;
            next = prev;
            prev = sum;
            yield return sum;
        }
    }
}
