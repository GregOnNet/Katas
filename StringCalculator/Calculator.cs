using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.StringCalculator
{
  public static class Calculator
  {
    public static int Add(string input)
    {
      if (string.IsNullOrEmpty(input))
        return 0;

      if (input.StartsWith("//"))
      {
        var regex = new Regex(@"//(?<delimiter>.+)\n");
        var delimiterMatch = regex.Match(input);
        var delimiter = delimiterMatch.Groups["delimiter"].Value;

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