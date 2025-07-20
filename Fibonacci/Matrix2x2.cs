using System.Numerics;

namespace Fibonacci
{
    public class Matrix2x2 : IMultiplyOperators<Matrix2x2, Matrix2x2, Matrix2x2>
    {
        private readonly UStringNumber[] content = new UStringNumber[3];

        public Matrix2x2(UStringNumber v1, UStringNumber v2, UStringNumber v3, UStringNumber v4)
        {
            content[0] = v1;
            content[1] = v2;
            content[2] = v3;
            content[3] = v4;
        }

        public static Matrix2x2 operator *(Matrix2x2 left, Matrix2x2 right)
        {
            throw new NotImplementedException();
        }
    }
}
