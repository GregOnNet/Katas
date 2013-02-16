using System;

namespace Kata.StringCalculator.Exceptions
{
  public class NegativesAreNoteAllowedException : Exception
  {
    public NegativesAreNoteAllowedException(string wrongNumbers)
      : base(String.Format("negatives not allowed {0}", wrongNumbers)) { }
  }
}