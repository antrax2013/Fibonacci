namespace Fibonacci;

public class UStringNumber
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
}
