from sources.modules.matrix.matrix1x2 import Matrix1x2
from sources.modules.matrix.matrix2x2 import Matrix2x2
from sources.api.interface_fibonacci_calculator import IFibonacciCalculator

class FibonacciMatrixCalculator(IFibonacciCalculator) :

    @staticmethod
    def getValue(index : int) -> int :
        T : Matrix2x2 = Matrix2x2(0, 1, 1, 1)
        M0 : Matrix1x2 = Matrix1x2( 1, 1)

        if (index == 0) :
            return 0

        if (index <= 2) :
            return 1

        tmp : Matrix2x2  = T.exponentN(index - 2)
        result : Matrix1x2  = M0.multiply(tmp)

        return result.Second