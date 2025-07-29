from sources.api.interface_fibonacci_calculator import IFibonacciCalculator

class FibonacciLoopCalculator(IFibonacciCalculator):

    @staticmethod
    def getValue(index : int) -> int:
        if index == 0 :
            return 0
        
        if index == 1 or index == 2 :
            return 1

        next = 1
        prev = 1
        for _ in range(2, index,1) :
            sum = next + prev
            next = prev
            prev = sum 

        return prev