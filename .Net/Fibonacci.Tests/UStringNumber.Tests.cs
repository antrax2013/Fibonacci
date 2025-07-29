using System.Text;

namespace Fibonacci.Tests;

public class UStringNumberTests
{
    [Theory]
    [InlineData("aa")]
    [InlineData("1a")]
    [InlineData("120.00")]
    [InlineData("120,00")]
    [InlineData("120 00")]
    [InlineData("+0")]
    [InlineData("-1")]
    public void When_UStringNumber_Is_Constructed_Not_Exclusively_With_Numbers_Then_An_Error_Fired(string value)
    {
        Assert.Throws<ArgumentException>(() => new UStringNumber(value));
    }

    [Theory]
    [InlineData("0", 1)]
    [InlineData("000000", 1)]
    [InlineData("0000012", 2)]
    [InlineData("00000000000000000000000001", 1)]
    [InlineData("000000000000000000000000010", 2)]
    public void When_UStringNumber_Is_Constructed_With_Value_StartWith_0_Then_Firsts_0_Are_Removed(string value, int expectedLength)
    {
        UStringNumber A = new(value);
        Assert.Equal(expectedLength, A.Value.Length);
    }


    [Theory]
    [InlineData("0", "0", "0")]
    [InlineData("9", "1", "10")]
    [InlineData("99", "1", "100")]
    [InlineData("44", "199", "243")]
    public void When_Two_UStringNumber_Are_Summed_Then_The_ExpectedResult_Is_Returned(string a, string b, string expectedResult)
    {
        UStringNumber A = new(a);
        UStringNumber B = new(b);

        UStringNumber res = A + B;
        Assert.Equal(expectedResult, res.Value);
    }

    [Fact]
    public void When_A_UStringNumber_Is_Constructed_With_An_Empty_String_Then_The_Value_Is_0()
    {
        UStringNumber A = new("");
        Assert.Equal("0", A.Value);
    }

    [Theory]
    [InlineData("0", "0", "0")]
    [InlineData("1", "1", "1")]
    [InlineData("9", "1", "9")]
    [InlineData("9", "9", "81")]
    [InlineData("44", "199", "8756")]
    [InlineData("129", "129", "16641")]
    public void When_Two_UStringNumber_Are_Multiplied_Then_The_ExpectedResult_Is_Returned(string a, string b, string expectedResult)
    {
        UStringNumber A = new(a);
        UStringNumber B = new(b);

        UStringNumber res = A * B;
        Assert.Equal(expectedResult, res.Value);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("9", "9")]
    [InlineData("1234567890", "1234567890")]
    [InlineData("1234567890", "01234567890")]
    public void When_Two_UStringNumber_Are_Equals_Then_The_Expected_Result_Is_True(string a, string b)
    {
        UStringNumber A = new(a);
        UStringNumber B = new(b);

        bool result = A.Equals(B);
        Assert.True(result);
    }

    [Fact]
    public void When_Two_Null_UStringNumber_Are_Compared_With_Equals_Method_Then_An_NullReferenceException_Is_Fired()
    {
        UStringNumber? A = null;
        UStringNumber? B = null;

#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
        Assert.Throws<NullReferenceException>(() => _ = A.Equals(B));
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
    }

    [Fact]
    public void When_A_Not_Null_UStringNumber_Is_Compared_With_Equals_Method_To_A_Null_UStringNumber_Then_The_Expected_Result_Is_False()
    {
        UStringNumber A = new("50");
        UStringNumber? B = null;

        Assert.False(A.Equals(B));
        Assert.True(A != B);
    }

    [Fact]
    public void When_A_Not_Null_UStringNumber_Is_Compared_With_Equals_Method_To_A_Not_Null_Object_Then_The_Expected_Result_Is_False()
    {
        UStringNumber A = new("50");
        StringBuilder B = new();

        Assert.False(A.Equals(B));
    }

    [Fact]
    public void When_A_Not_Null_UStringNumber_Is_Compared_With_Equals_Method_To_A_Not_Null_UStringNumber_With_Same_Value_Casted_In_Object_Then_The_Expected_Result_Is_True()
    {
        UStringNumber A = new("50");
        object B = new UStringNumber("50");

        Assert.True(A.Equals(B));

#pragma warning disable CS0253 // Possibilité d'une comparaison de références involontaire ; la partie droite a besoin d'un cast
        Assert.True(A != B); //Cause not use UStringNumber operator != but object operator !=
#pragma warning restore CS0253 // Possibilité d'une comparaison de références involontaire ; la partie droite a besoin d'un cast
    }

    [Fact]
    public void When_A_Not_Null_UStringNumber_Is_Compared_With_Equals_Method_To_A_String_With_Same_ValueThen_The_Expected_Result_Is_False()
    {
        UStringNumber A = new("50");
        string B = new("50");

        Assert.False(A.Equals(B));
    }

    [Theory]
    [InlineData("0", 0, "1")]
    [InlineData("0", 1, "0")]
    [InlineData("1", 100, "1")]
    [InlineData("2", 3, "8")]
    [InlineData("2", 5, "32")]
    [InlineData("129", 2, "16641")]
    [InlineData("1234567890", 0, "1")]
    [InlineData("1234567890", 1, "1234567890")]
    [InlineData("1234567890", 2, "1524157875019052100")]
    public void When_The_Exponential_Of_UStringNumber_Is_Computed_Then_The_Expected_Result_Is_Returned(string a, int b, string expectedResult)
    {
        UStringNumber A = new(a);
        UStringNumber result = A ^ (UInt128)b;
        Assert.Equal(expectedResult, result.Value);
    }
}
