from sources.modules.matrix.matrix2x2 import Matrix2x2

class Matrix1x2 :
  First : int
  Second : int

  def __init__(self, first : int, second : int) -> None :
      self.First = first
      self.Second = second

  def multiply(self, right : Matrix2x2) :
    v1 = self.First * right.First + self.Second * right.Third
    v2 = self.First * right.Second + self.Second * right.Fourth
    return Matrix1x2(v1, v2)
