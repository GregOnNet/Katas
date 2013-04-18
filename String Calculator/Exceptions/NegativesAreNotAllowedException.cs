using System;

namespace Kata.StringCalculator.Exceptions
{
  public class NegativesAreNotAllowedException : Exception
  {
    public NegativesAreNotAllowedException(string wrongNumbers)
      : base(String.Format("negatives not allowed {0}", wrongNumbers)) { }
  }
}