namespace Fibonacci.Tests;

public class Matrix2x2Tests
{
    public static IEnumerable<object[]> MatrixMultiplicationCases =>
    [
        [
            new Matrix2x2(new("2"), new("3"), new("1"), new("2")),
            Matrix2x2.IDENTITY,
            new Matrix2x2(new("2"), new("3"), new("1"), new("2")),
        ],
        [
            new Matrix2x2(new("2"), new("3"), new("1"), new("2")),
            new Matrix2x2(new("0"), new("0"), new("0"), new("0")),
            new Matrix2x2(new("0"), new("0"), new("0"), new("0"))
        ],
        [
            new Matrix2x2(new("2"), new("3"), new("1"), new("2")),
            new Matrix2x2(new("4"), new("5"), new("6"), new("7")),
            new Matrix2x2(new("26"), new("31"), new("16"), new("19"))
        ],
        [
            new Matrix2x2(new("2"), new("3"), new("0"), new("0")),
            new Matrix2x2(new("0"), new("1"), new("1"), new("1")),
            new Matrix2x2(new("3"), new("5"), new("0"), new("0"))
        ]
    ];

    [Theory]
    [MemberData(nameof(MatrixMultiplicationCases))]
    public void When_2_Matrix2x2_Are_Multiplied_Then_The_Expected_Result_Is_Returned(Matrix2x2 M1, Matrix2x2 M2, Matrix2x2 expected)
    {
        Matrix2x2 result = M1 * M2;
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> MatrixNExponentCases =>
    [
        [
            new Matrix2x2(new ("2"), new ("3"), new ("1"), new ("2")),
            0,
            Matrix2x2.IDENTITY,
        ],
        [
            new Matrix2x2(new ("2"), new ("3"), new ("1"), new ("2")),
            1,
            new Matrix2x2(new ("2"), new ("3"), new ("1"), new ("2"))
        ],
        [
            new Matrix2x2(new ("2"), new ("3"), new ("1"), new ("2")),
            2,
            new Matrix2x2(new ("7"), new ("12"), new ("4"), new ("7"))
        ],
    ];


    [Theory]
    [MemberData(nameof(MatrixNExponentCases))]
    public void When_The_Exponent_N_Of_A_Matrix2x2_Is_Computed_Then_The_Expected_Result_Is_Returned(Matrix2x2 input, UInt128 exponent, Matrix2x2 expected)
    {
        Matrix2x2 result = input ^ exponent;

        Assert.Equal(expected, result);
    }
}