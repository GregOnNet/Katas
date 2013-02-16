using System;
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

      if (input.StartsWith("//"))
      {
        var delimiter = DelimiterPattern
                          .Match(input)
                          .Groups["delimiter"]
                          .Value;

        input = input
                  .Replace(delimiter, ",")
                  .Replace("//,\n", "");
      }

      var numbers = input
        .Split(",\n".ToArray())
        .Select(int.Parse)
        .Where(x => x <= 1000)
        .ToList();

      if (numbers.Any(n => n < 0))
        throw new NegativesAreNoteAllowedException(String.Join(",", numbers.Where(n => n < 0)));

      return numbers.Where(n => n >= 0).Sum();
    }
  }
}