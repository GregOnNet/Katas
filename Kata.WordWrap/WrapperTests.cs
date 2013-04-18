using NUnit.Framework;

namespace Kata.WordWrap
{
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