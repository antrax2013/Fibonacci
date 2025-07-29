from abc import ABCMeta, abstractmethod

class IFibonacciCalculator:
  __metaclass__ = ABCMeta

  @abstractmethod
  def getValue(index : float) -> float: pass