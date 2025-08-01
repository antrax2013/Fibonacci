class Matrix2x2 :
  First : int
  Second : int
  Third : int
  Fourth : int

  def __init__(self, first : int, second : int, third : int, fourth : int) -> None :
      self.First = first
      self.Second = second
      self.Third = third
      self.Fourth = fourth

  def multiply(self, right) :
    v1 = self.First * right.First + self.Second * right.Third
    v2 = self.First * right.Second + self.Second * right.Fourth
    v3 = self.Third * right.First + self.Fourth * right.Third
    v4 = self.Third * right.Second + self.Fourth * right.Fourth
    return Matrix2x2(v1, v2, v3, v4)
  
  @staticmethod
  def getIdentity():
    return Matrix2x2(1, 0, 0, 1)

  def exponentN(self, n : int) :
    result : Matrix2x2 = Matrix2x2.getIdentity()
    tmp : Matrix2x2 = Matrix2x2(self.First, self.Second, self.Third, self.Fourth)

    if (n == 1) :
      return tmp
    
    while (n > 0) :
      if (n % 2 == 1) :
        result = result.multiply(tmp)
      
      tmp = tmp.multiply(tmp)
      n = n // 2

    return result
