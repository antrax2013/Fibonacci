using System.Numerics;

namespace Fibonacci;

public class UStringNumber :
    IAdditionOperators<UStringNumber, UStringNumber, UStringNumber>,
    IMultiplyOperators<UStringNumber, UStringNumber, UStringNumber>,
    IEquatable<UStringNumber>,
    IEqualityOperators<UStringNumber, UStringNumber, Boolean>
{
    private string value;
    public string Value
    {
        get { return value; }
        set
        {
            this.value = value.TrimStart('0');
            if (this.value.Length == 0)
                this.value = "0";
            else
            {
                for (int i = 0; i < this.value.Length; i++)
                {
                    if (!int.TryParse(this.value[i].ToString(), out _))
                        throw new ArgumentException($"Value {value} is not a unsigned number");
                }
            }
        }
    }

    public override string ToString()
    {
        return Value;
    }

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur autre que Null lors de la fermeture du constructeur. Envisagez d’ajouter le modificateur « required » ou de déclarer le champ comme pouvant accepter la valeur Null.
    public UStringNumber(string value = "0") => Value = value;

    public UStringNumber()
    {
        value = "0";
    }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur autre que Null lors de la fermeture du constructeur. Envisagez d’ajouter le modificateur « required » ou de déclarer le champ comme pouvant accepter la valeur Null.


    private int GetValueFromEnd(int reverseIndex)
    {
        _ = int.TryParse(Value.Length >= reverseIndex ? Value[^reverseIndex].ToString() : "0", out int result);
        return result;
    }

    private static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private UStringNumber Add(UStringNumber other)
    {
        int biggest = other.Value.Length > Value.Length ? other.Value.Length : Value.Length;
        List<string> result = [];

        int prev = 0;
        int otherVal, val, sum;

        for (int i = 1; i <= biggest; i++)
        {
            otherVal = other.GetValueFromEnd(i);
            val = this.GetValueFromEnd(i);

            sum = otherVal + val + prev;
            prev = 0;

            if (sum > 9)
            {
                prev = 1;
                sum %= 10;
            }

            result.Add(sum.ToString());
        }

        if (prev != 0)
            result.Add(prev.ToString());

        string r = string.Join("", result);
        return new UStringNumber(Reverse(r));
    }

    private UStringNumber Multiply(UStringNumber other)
    {
        int shortest = other.Value.Length < Value.Length ? other.Value.Length : Value.Length;

        List<string> tmp = [];
        UStringNumber result = new();

        int prev = 0;
        int otherVal, val, sum;

        for (int i = 1; i <= Value.Length; i++)
        {
            tmp = [];
            tmp.AddRange(Enumerable.Repeat(0, i - 1).Select(i => i.ToString()));
            prev = 0;

            for (int j = 1; j <= other.Value.Length; j++)
            {
                otherVal = other.GetValueFromEnd(j);
                val = this.GetValueFromEnd(i);

                sum = otherVal * val + prev;
                prev = 0;

                if (sum > 9)
                {
                    prev = sum / 10;
                    sum %= 10;
                }

                tmp.Add(sum.ToString());
            }
            if (prev != 0)
                tmp.Add(prev.ToString());

            string r = string.Join("", tmp);
            result += new UStringNumber(Reverse(r));
        }

        return result;
    }

    public override bool Equals(object? other)
    {
        if (other is not UStringNumber) return false;
        return this.Equals((UStringNumber)other);
    }

    public bool Equals(UStringNumber? other)
    {
        return Value == other?.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(value, Value);
    }

    public static UStringNumber operator +(UStringNumber left, UStringNumber right)
    {
        return left.Add(right);
    }

    public static UStringNumber operator *(UStringNumber left, UStringNumber right)
    {
        return left.Multiply(right);
    }

    public static UStringNumber operator ^(UStringNumber current, UInt128 n)
    {
        UStringNumber result = new("1");
        UStringNumber tmp = new(current.Value);

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                result *= tmp;
            }
            tmp *= tmp;
            n /= 2;
        }

        return result;
    }

    public static bool operator ==(UStringNumber? left, UStringNumber? right)
    {
        return left!.Equals(right);
    }

    public static bool operator !=(UStringNumber? left, UStringNumber? right)
    {
        return !left!.Equals(right);
    }


}
