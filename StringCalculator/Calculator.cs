using System;
using System.Linq;
using Kata.StringCalculator.Core;
using Kata.StringCalculator.Exceptions;

namespace Kata.StringCalculator
{
  public static class Calculator
  {
    public static int Add(string input)
    {
      if (string.IsNullOrEmpty(input))
        return 0;

      var numbers = new Extract()
                          .StringOfNumbers(input)
                          .NumbersFromString()
                          .Result();

      if (numbers.Any(n => n < 0))
        throw new NegativesAreNoteAllowedException(
                    String.Join(",", numbers.Where(n => n < 0)));

      return numbers.Sum();
    }
  }
}