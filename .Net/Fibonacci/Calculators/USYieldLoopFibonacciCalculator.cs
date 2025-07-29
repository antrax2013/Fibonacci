using Fibonacci.API;

namespace Fibonacci.Calculators;

public class USYieldLoopFibonacciCalculator : IFibonacciCalculator<UStringNumber>
{
    public static UStringNumber GetValue(UInt128 index)
    {
        IEnumerable<UStringNumber> values = GenerateSequence(index);
        return values.Last();
    }

    private static IEnumerable<UStringNumber> GenerateSequence(UInt128 index)
    {
        yield return new("0");
        if (index == 0) yield break;

        yield return new("1");
        if (index == 1) yield break;

        yield return new("1");
        if (index == 2) yield break;

        UStringNumber next = new("1");
        UStringNumber prev = new("1");
        for (UInt128 i = 2; i < index; i++)
        {
            UStringNumber sum = next + prev;
            next = prev;
            prev = sum;
            yield return sum;
        }
    }
}
