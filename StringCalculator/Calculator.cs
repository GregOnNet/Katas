using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.StringCalculator
{
  public static class Calculator
  {
    private static readonly Regex DelimiterPattern = new Regex(@"//(?<delimiter>.+)\n");

    public static int Add(string input)
    {
      if (string.IsNullOrEmpty(input))
        return 0;

      input = ExtractStringOfNumbers(input);
      var numbers = ExtractNumbersOfString(input);

      if (numbers.Any(n => n < 0))
        throw new NegativesAreNoteAllowedException(
                    String.Join(",", numbers.Where(n => n < 0)));

      return numbers.Sum();
    }

    static List<int> ExtractNumbersOfString(string input)
    {
      var numbers = input
        .Split(",\n".ToArray())
        .Select(int.Parse)
        .Where(x => x <= 1000)
        .ToList();
      return numbers;
    }

    private static string ExtractStringOfNumbers(string input)
    {
      if (!input.StartsWith("//"))
        return input;
     
      var delimiter = DelimiterPattern
                        .Match(input)
                        .Groups["delimiter"]
                        .Value;

      return input
        .Replace(delimiter, ",")
        .Replace("//,\n", "");
    }
  }
}