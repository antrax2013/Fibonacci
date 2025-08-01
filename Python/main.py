import time
import sys
sys.path.append('/sources')
from sources.modules.loop_fibonacci_calculator import FibonacciLoopCalculator
from sources.modules.fibonacci.matrix_calculator import FibonacciMatrixCalculator

index = 50000
start_time = time.time()
result = FibonacciMatrixCalculator.getValue(index)
end_time = time.time()

print(f"Fibonacci matrix claculator in python {index}th = {result}")
print("Elapsed time  : %s seconds" % (end_time - start_time))

start_time = time.time()
result = FibonacciLoopCalculator.getValue(index)
end_time = time.time()

print(f"Fibonacci matrix claculator in python {index}th = {result}")
print("Elapsed time  : %s seconds" % (end_time - start_time))
