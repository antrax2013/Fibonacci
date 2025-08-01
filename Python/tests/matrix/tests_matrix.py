import sys
sys.path.append('../')

import unittest
from parameterized import parameterized

from sources.modules.matrix.matrix1x2 import Matrix1x2
from sources.modules.matrix.matrix2x2 import Matrix2x2

class MatrixTests(unittest.TestCase):
  @parameterized.expand([
     [Matrix1x2(1, 1), Matrix2x2(0, 1, 1, 1), Matrix1x2(1, 2)]
    ,[Matrix1x2(1, 1), Matrix2x2(1, 1, 1, 1), Matrix1x2(2, 2)]
    ,[Matrix1x2(1, 1), Matrix2x2(0, 0, 0, 0), Matrix1x2(0, 0)]
    ,[Matrix1x2(2, 3), Matrix2x2(0, 1, 1, 1), Matrix1x2(3, 5)]
  ])
  def test_MatrixMultiplication_Between_Matrix1x2_And_Matrix2x2(self, m1 : Matrix1x2, m2 : Matrix2x2, expected : Matrix1x2):
     result : Matrix1x2 = m1.multiply(m2)
     self.assertEqual(result.First, expected.First)
     self.assertEqual(result.Second, expected.Second)

  @parameterized.expand([
     [Matrix2x2(2, 3, 1 ,2), Matrix2x2.getIdentity(), Matrix2x2(2, 3, 1 ,2)]
    ,[Matrix2x2(2, 3, 1 ,2), Matrix2x2(0, 0, 0, 0), Matrix2x2(0, 0, 0, 0)]
    ,[Matrix2x2(2, 3, 1 ,2), Matrix2x2(4, 5, 6, 7), Matrix2x2(26, 31, 16, 19)]
    ,[Matrix2x2(2, 3, 0 ,0), Matrix2x2(0, 1, 1, 1), Matrix2x2(3, 5, 0, 0)]
  ])
  def test_MatrixMultiplication_Between_2_Matrix2x2(self, m1 : Matrix2x2, m2 : Matrix2x2, expected : Matrix2x2):
     result : Matrix2x2 = m1.multiply(m2)
     self.assertEqual(result.First, expected.First)
     self.assertEqual(result.Second, expected.Second)
     self.assertEqual(result.Third, expected.Third)
     self.assertEqual(result.Fourth, expected.Fourth)            

  @parameterized.expand([
     [Matrix2x2(2, 3, 1 ,2), 0, Matrix2x2.getIdentity()]
    ,[Matrix2x2(2, 3, 1 ,2), 1, Matrix2x2(2, 3, 1 ,2)]
    ,[Matrix2x2(2, 3, 1 ,2), 2, Matrix2x2(7, 12, 4 ,7)]  
  ])
  def test_MatrixExponent(self, m1 : Matrix2x2, n : int, expected : Matrix2x2):
     result : Matrix2x2 = m1.exponentN(n)
     self.assertEqual(result.First, expected.First)
     self.assertEqual(result.Second, expected.Second)
     self.assertEqual(result.Third, expected.Third)
     self.assertEqual(result.Fourth, expected.Fourth)


if __name__ == '__main__':
    unittest.main()