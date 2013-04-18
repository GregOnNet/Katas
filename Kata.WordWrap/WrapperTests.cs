using System.Linq;
using NUnit.Framework;

namespace Kata.WordWrap
{
  // You write a class called Wrapper, that has a single
  // static function named wrap that takes two arguments, 
  // a string, and a column number. The function returns the string, 
  // but with line breaks inserted at just the right places to make sure
  // that no line is longer than the column number. You try to break 
  // lines at word boundaries.
  // Like a word processor, break the line by replacing the last space in a line with a newline.

  [TestFixture]
  public class WrapperTests
  {
    [TestCase("Hi my name is...", 20)]
    public void When_the_wrapper_takes_a_text_shorter_than_the_collumn_number_it_should_return_the_text(string text, int columnNumber)
    {
      string actual = Wrapper.Wrap(text, columnNumber);

      Assert.AreEqual(text, actual);
    }

    [TestCase("Hi my name is Gregor Jan.", 20)]
    public void When_the_wrapper_takes_a_text_longer_than_the_collumn_number_it_should_break(string text, int columnNumber)
    {
      string expected = "Hi my name is \nGregor Jan.";

      string actual = Wrapper.Wrap(text, columnNumber);

      Assert.AreEqual(expected, actual);
    }

    [TestCase("Only insert a line break on word bounderies!", 20)]
    public void When_a_line_reached_the_collumn_number_a_line_break_should_be_inserted_before(string text, int columnNumber)
    {
      string expected = "Only insert a line \nbreak on word \nbounderies!";

      string actual = Wrapper.Wrap(text, columnNumber);

      Assert.AreEqual(expected, actual);
    }
  }
}