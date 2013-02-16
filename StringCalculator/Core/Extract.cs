using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Kata.StringCalculator.Infrastructure;

namespace Kata.StringCalculator.Core
{
  public class Extract : IExtract
  {
    private static readonly Regex DelimiterPattern = new Regex(@"//(?<delimiter>.+)\n");

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