using System.Numerics;

namespace Fibonacci
{
    public class Matrix2x2 : IMultiplyOperators<Matrix2x2, Matrix2x2, Matrix2x2>, IEquatable<Matrix2x2>, IEqualityOperators<Matrix2x2, Matrix2x2, Boolean>
    {
        private readonly UStringNumber[] content = new UStringNumber[4];

        public UStringNumber First => content[0];
        public UStringNumber Second => content[1];
        public UStringNumber Third => content[2];
        public UStringNumber Fourth => content[3];


        public Matrix2x2(UStringNumber v1, UStringNumber v2, UStringNumber v3, UStringNumber v4)
        {
            content[0] = v1;
            content[1] = v2;
            content[2] = v3;
            content[3] = v4;
        }

        public static Matrix2x2 operator *(Matrix2x2 left, Matrix2x2 right)
        {
            UStringNumber v1 = left.First * right.First + left.Second * right.Third;
            UStringNumber v2 = left.First * right.Second + left.Second * right.Fourth;
            UStringNumber v3 = left.Third * right.First + left.Fourth * right.Third;
            UStringNumber v4 = left.Third * right.Second + left.Fourth * right.Fourth;

            return new(v1, v2, v3, v4);
        }

        public static bool operator ==(Matrix2x2? left, Matrix2x2? right)
        {
            return left!.Equals(right);
        }

        public static bool operator !=(Matrix2x2? left, Matrix2x2? right)
        {
            return !left!.Equals(right);
        }

        public static readonly Matrix2x2 IDENTITY = new(new("1"), new("0"), new("0"), new("1"));

        public bool Equals(Matrix2x2? other)
        {
            bool areEquals = true;
            areEquals &= this.First.Equals(other!.First);
            areEquals &= this.Second.Equals(other!.Second);
            areEquals &= this.Third.Equals(other!.Third);
            areEquals &= this.Fourth.Equals(other!.Fourth);
            return areEquals;
        }

        public override bool Equals(object? other)
        {
            if (other is not Matrix2x2) return false;
            return this.Equals((Matrix2x2)other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(content, First, Second, Third, Fourth);
        }
    }
}
