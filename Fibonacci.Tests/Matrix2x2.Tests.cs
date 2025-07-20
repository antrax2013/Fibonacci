namespace Fibonacci.Tests
{
    public class Matrix2x2Tests
    {
        [Fact]
        void When_2_Matrix2x2_Are_Multiplied_Then_The_Expected_Result_Is_Returned()
        {
            Matrix2x2 M1 = new(new("1"), new("1"), new("1"), new("1"));
            Matrix2x2 M2 = new(new("1"), new("1"), new("1"), new("1"));

            Assert.Throws<NotImplementedException>(() => M1 * M2);
        }
    }
}
