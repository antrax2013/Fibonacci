using System.Numerics;

namespace Fibonacci;


public class Matrix1x2 : IMultiplyOperators<Matrix1x2, Matrix2x2, Matrix1x2>, IEquatable<Matrix1x2>, IEqualityOperators<Matrix1x2, Matrix1x2, Boolean>
{
    private readonly UStringNumber[] content = new UStringNumber[2];

    public UStringNumber First => content[0];
    public UStringNumber Second => content[1];

    public Matrix1x2(UStringNumber v1, UStringNumber v2)
    {
        content[0] = v1;
        content[1] = v2;
    }

    public static Matrix1x2 Clone(Matrix1x2 matrix)
    {
        return new(matrix.First, matrix.Second);
    }

    public static Matrix1x2 operator *(Matrix1x2 left, Matrix2x2 right)
    {
        UStringNumber v1 = left.First * right.First + left.Second * right.Third;
        UStringNumber v2 = left.First * right.Second + left.Second * right.Fourth;

        return new(v1, v2);
    }

    public static bool operator ==(Matrix1x2? left, Matrix1x2? right)
    {
        return left!.Equals(right);
    }

    public static bool operator !=(Matrix1x2? left, Matrix1x2? right)
    {
        return !left!.Equals(right);
    }


    public bool Equals(Matrix1x2? other)
    {
        bool areEquals = true;
        areEquals &= this.First.Equals(other!.First);
        areEquals &= this.Second.Equals(other!.Second);
        return areEquals;
    }

    public override bool Equals(object? other)
    {
        if (other is not Matrix1x2) return false;
        return this.Equals((Matrix1x2)other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(content, First, Second);
    }
}
