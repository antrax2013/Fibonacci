namespace Fibonacci.Tests;

public class Matrix1x2Tests
{
    public static IEnumerable<object[]> MatrixMultiplicationCases =>
    [
        [
            new Matrix1x2(new("1"), new("1")),
            new Matrix2x2(new("0"), new("1"), new("1"), new("1")),
            new Matrix1x2(new("1"), new("2")),
        ],
        [
            new Matrix1x2(new("1"), new("1")),
            new Matrix2x2(new("1"), new("1"), new("1"), new("1")),
            new Matrix1x2(new("2"), new("2")),
        ],
        [
            new Matrix1x2(new("1"), new("1")),
            new Matrix2x2(new("0"), new("0"), new("0"), new("0")),
            new Matrix1x2(new("0"), new("0")),
        ],
        [
            new Matrix1x2(new("2"), new("3")),
            new Matrix2x2(new("0"), new("1"), new("1"), new("1")),
            new Matrix1x2(new("3"), new("5"))
        ]
    ];

    [Theory]
#pragma warning disable xUnit1042 // The member referenced by the MemberData attribute returns untyped data rows
    [MemberData(nameof(MatrixMultiplicationCases))]
#pragma warning restore xUnit1042 // The member referenced by the MemberData attribute returns untyped data rows
    public void When_2_Matrix_Are_Multiplied_Then_The_Expected_Result_Is_Returned(Matrix1x2 M1, Matrix2x2 M2, Matrix1x2 expected)
    {
        Matrix1x2 result = M1 * M2;
        Assert.Equal(expected, result);
    }

    [Fact]
    public void When_A_Matrix2x2_Is_Multiply_By_Identity_Matrix_Then_The_Result_Is_The_Provided_Matrix()
    {
        Matrix1x2 M1 = new(new("2"), new("3"));
        Matrix1x2 result = M1 * Matrix2x2.IDENTITY;

        Assert.True(M1 == result);
    }
}