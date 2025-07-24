using Fibonacci.API;

namespace Fibonacci.Calculators;

public class MatrixFibonacciCalulator : IFibonacciCalculator<UStringNumber>
{
    private static readonly Matrix2x2 T = new(new("0"), new("1"), new("1"), new("1"));
    private static readonly Matrix2x2 M0 = new(new("1"), new("1"), new("0"), new("0"));

    public static UStringNumber GetValue(UInt128 index)
    {
        if (index == 0)
            return new();

        if (index <= 2)
            return new("1");

        Matrix2x2 tmp = T ^ (index - 2);
        Matrix2x2 res = (M0 * tmp);

        return res.Second;
    }
}
