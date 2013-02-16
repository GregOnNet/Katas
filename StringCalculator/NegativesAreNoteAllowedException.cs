using System;

namespace Kata.StringCalculator
{
  public class NegativesAreNoteAllowedException : Exception
  {
    public NegativesAreNoteAllowedException(string wrongNumbers)
      : base(String.Format("negatives not allowed {0}", wrongNumbers)) { }
  }
}