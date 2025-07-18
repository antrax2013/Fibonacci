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
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("332825110087067562321196029789634457848", "332825110087067562321196029789634457848")]
    public void When_Two_UStringNumber_Are_Equals_Then_Return_True(string a, string b)
    {
        UStringNumber A = new(a);
        UStringNumber B = new(b);

        bool result = A.Equals(B);
        Assert.True(result);
    }

    [Fact]
    public void When_Two_UStringNumber_Are_Same_Object_Then_Equals_Method_Returns_True()
    {
        UStringNumber A = new("1231056");
        UStringNumber B = A;

        bool result = A.Equals(B);
        Assert.True(result);
    }


    [Theory]
    [InlineData("0", "0", "0")]
    [InlineData("9", "1", "10")]
    [InlineData("99", "1", "100")]
    [InlineData("44", "199", "243")]
    public void When_Two_UStringNumber_Are_Summed_Then_The_ExpectedResult_Is_Return(string a, string b, string expectedResult)
    {
        UStringNumber A = new(a);
        UStringNumber B = new(b);

        UStringNumber res = A.Add(B);
        Assert.Equal(expectedResult, res.Value);

    }

    [Theory]
    [InlineData("0", "1")]
    [InlineData("9", "10")]
    [InlineData("99", "100")]
    [InlineData("44", "45")]
    [InlineData("342825110087067562321196029789634457848", "342825110087067562321196029789634457849")]
    public void When_UStringNumber_Is_Incremented_Then_The_ExpectedResult_Is_Return(string a, string expectedResult)
    {
        UStringNumber A = new(a);

        A++;
        Assert.Equal(expectedResult, A.Value);
    }
}
