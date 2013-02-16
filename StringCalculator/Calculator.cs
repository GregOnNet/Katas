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

      var numbers = new Extract()
                          .StringOfNumbers(input)
                          .NumbersFromString()
                          .Result();

      if (numbers.Any(n => n < 0))
        throw new NegativesAreNoteAllowedException(
                    String.Join(",", numbers.Where(n => n < 0)));

      return numbers.Sum();
    }

    public interface IExtract
    {
      IExtract StringOfNumbers(string input);
      IExtract NumbersFromString();
      IList<int> Result();
    }

    public class Extract : IExtract
    {
      private string _stringOfNumber;
      private List<int> _extractedNumbers;

      public IExtract StringOfNumbers(string input)
      {
        if (input.StartsWith("//"))
        {
          var delimiter = DelimiterPattern
            .Match(input)
            .Groups["delimiter"]
            .Value;

          _stringOfNumber = input
            .Replace(delimiter, ",")
            .Replace("//,\n", "");
        }
        else
        {
          _stringOfNumber = input;
        }

        return this;
      }

      public IExtract NumbersFromString()
      {
        _extractedNumbers = _stringOfNumber
                              .Split(",\n".ToArray())
                              .Select(int.Parse)
                              .Where(x => x <= 1000)
                              .ToList();

        return this;
      }

      public IList<int> Result()
      {
        return _extractedNumbers;
      }
    }
  }
}