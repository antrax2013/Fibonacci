namespace Fibonacci;

public class UStringNumber : IComparable<UStringNumber>, IEquatable<UStringNumber>
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

    public UStringNumber(string value = "0") => Value = value;

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

    public UStringNumber Add(UStringNumber other)
    {
        int length = other.Value.Length > Value.Length ? other.Value.Length : Value.Length;
        List<string> result = [];

        int prev = 0;
        int otherVal, val, sum;

        for (int i = 1; i <= length; i++)
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

    public override int GetHashCode() => Value.GetHashCode();

    public int CompareTo(UStringNumber? other)
    {
        if (other is null) return 1;

        if (other.Equals(this)) return 0;

        if (other.Value.Length < Value.Length) return 1;
        if (other.Value.Length > Value.Length) return -1;

        for (int i = 0; i < Value.Length; i++)
        {
            _ = int.TryParse(other.Value[i].ToString(), out int otherVal);
            _ = int.TryParse(Value[i].ToString(), out int val);
            if (otherVal == val)
                continue;
            return val.CompareTo(otherVal);
        }
        throw new NotImplementedException();
    }

    public static UStringNumber operator ++(UStringNumber obj)
    {
        return obj.Add(new("1"));
    }

    public bool Equals(UStringNumber? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return (Value == other.Value);
    }

    public static bool operator ==(UStringNumber left, UStringNumber right)
    {
        if (left?.Value != right?.Value)
            return false;

        return left!.Equals(right);
    }

    public static bool operator !=(UStringNumber a, UStringNumber b) => !(a == b);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is null)
            return false;

        throw new NotImplementedException();
    }

    public static bool operator <(UStringNumber left, UStringNumber right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(UStringNumber left, UStringNumber right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(UStringNumber left, UStringNumber right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    public static bool operator >=(UStringNumber left, UStringNumber right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }
}
