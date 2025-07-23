namespace Fibonacci.Tests
{
    public class Matrix2x2Tests
    {
        [Fact]
        public void When_2_Matrix2x2_Are_Multiplied_Then_The_Expected_Result_Is_Returned()
        {
            Matrix2x2 M1 = new(new("2"), new("3"), new("1"), new("2"));
            Matrix2x2 M2 = new(new("1"), new("3"), new("3"), new("2"));

            Matrix2x2 result = M1 * M2;

            Assert.Equal("11", result.First.Value);
            Assert.Equal("12", result.Second.Value);
            Assert.Equal("7", result.Third.Value);
            Assert.Equal("7", result.Fourth.Value);

        }

        [Fact]
        public void When_A_Matrix2x2_Is_Multiply_By_Identity_Matrix_Then_The_Result_Is_The_Provided_Matrix()
        {
            Matrix2x2 M1 = new(new("2"), new("3"), new("1"), new("2"));
            Matrix2x2 result = M1 * Matrix2x2.IDENTITY;

            Assert.True(M1 == result);
        }

        [Fact]
        public void When_The_Exponent_N_Of_A_Matrix2x2_Is_Computed_Then_The_Expected_Result_Is_Returned()
        {
            Matrix2x2 M1 = new(new("2"), new("3"), new("1"), new("2"));
            Assert.Throws<NotImplementedException>(() => M1 ^ 1);
        }
    }
}
