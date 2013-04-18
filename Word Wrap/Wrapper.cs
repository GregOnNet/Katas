using System;

namespace Kata.WordWrap
{
  public class Wrapper
  {
    public static string Wrap(string text, int lengthOfLine)
    {
      if (text.Length <= lengthOfLine)
        return text;

      var line = text.Substring(0, lengthOfLine - 1);
      var rest = text.Substring(lengthOfLine - 1);
      
      var result = BreakLineBehindLastSpace(line);
    
      if (rest.Length >= lengthOfLine)
        result += Wrap(rest, lengthOfLine);
      else
        result += rest;

      return result;
    }

    public static string BreakLineBehindLastSpace(string line)
    {
      return line.Insert(BehindLastSpaceOf(line),
                         "\n");
    }

    private static int BehindLastSpaceOf(string line)
    {
      return line.LastIndexOf(" ", StringComparison.Ordinal) + 1;
    }
  }
}