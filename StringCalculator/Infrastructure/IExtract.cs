using System.Collections.Generic;

namespace Kata.StringCalculator.Infrastructure
{
  public interface IExtract
  {
    IExtract StringOfNumbers(string input);
    IExtract NumbersFromString();
    IList<int> Result();
  }
}