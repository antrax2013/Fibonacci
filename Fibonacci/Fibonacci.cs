namespace Fibonacci;

public static class Fibonacci
{
    private static IEnumerable<UInt128> GenerateSuite(uint index)
    {
        yield return 0;
        if (index == 0) yield break;

        yield return 1;
        if (index == 1) yield break;

        yield return 1;
        if (index == 2) yield break;

        UInt128 next = 1;
        UInt128 prev = 1;
        for (int i = 2; i < index; i++)
        {
            UInt128 sum = next + prev;
            next = prev;
            prev = sum;
            yield return sum;
        }
    }

    private static IEnumerable<UStringNumber> GenerateUSSuite(UInt128 index)
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
            UStringNumber sum = next.Add(prev);
            next = prev;
            prev = sum;
            yield return sum;
        }
    }

    public static UStringNumber Generate(UInt128 index)
    {
        if (index == 0) return new("0");
        if (index <= 2) return new("1");

        UStringNumber next = new("1");
        UStringNumber prev = new("1");
        for (UInt128 i = 2; i < index; i++)
        {
            UStringNumber sum = next.Add(prev);
            next = prev;
            prev = sum;
        }
        return prev;
    }

    public static UInt128 GetValue(uint index)
    {
        IEnumerable<UInt128> values = GenerateSuite(index);
        return values.Last();
    }

    public static UStringNumber GetValue(UInt128 index)
    {
        IEnumerable<UStringNumber> values = GenerateUSSuite(index);
        return values.Last();
    }

}
