using System;
using NUnit.Framework;

namespace Kata.StringCalculator
{
  public class StringCalculatorTests
  {
    [Test]
    public void When_the_input_is_empty_it_should_return_0()
    {
      var input = String.Empty;

      var result = StringCalc.Add(input);

      Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void When_The_input_is_1_it_should_return_1()
    {
      var input = "1";

      var result = StringCalc.Add(input);

      Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void When_The_input_is_1_and_2_should_return_3()
    {
      var input = "1,2";

      var result = StringCalc.Add(input);

      Assert.AreEqual(3, result);
    }

    [TestCase("", 0)]
    [TestCase("1", 1)]
    [TestCase("1,2", 3)]
    [TestCase("1,2,3", 6)]
    [TestCase("1,2,3,4,5,6,7,8,9", 45)]
    public void Should_add_numbers(string input, int expectedSum)
    {
      var result = StringCalc.Add(input);

      Assert.AreEqual(expectedSum, result);
    }

    [TestCase("1,2,3,4,5,6,7\n8,9", 45)]
    public void Should_add_numbers_when_input_contains_new_lines(string input, int expectedSum)
    {
      var result = StringCalc.Add(input);

      Assert.AreEqual(expectedSum, result);
    }

    [TestCase("1,2,3,4,5,6,7,\n8,9", 45)]
    [ExpectedException]
    public void Should_fail_when_input_has_comma_followed_by_new_line(string input, int expectedSum)
    {
      StringCalc.Add(input);
    }

    [TestCase("//;\n1;2", 3)]
    [TestCase("//x\n1x2", 3)]
    [TestCase("//a\n1a2", 3)]
    public void When_a_custom_one_char_separator_is_defined_with_the_input_of_1_and_2_it_should_return_3(string input, int expectedSum)
    {
      var result = StringCalc.Add(input);

      Assert.AreEqual(expectedSum, result);
    }


    [TestCase("//***\n1***2***3", 6)]
    public void When_a_custom_multichar_separator_is_defined_with_the_input_of_1_and_2_it_should_return_3(string input, int expectedSum)
    {

      var result = StringCalc.Add(input);

      Assert.AreEqual(expectedSum, result);
    }

    [TestCase("-1,2")]
    [ExpectedException(ExpectedMessage = "negatives not allowed -1")]
    public void Should_throw_exception_when_negative_numbers_are_passed1(string input)
    {
      StringCalc.Add(input);
    }

    [TestCase("//;\n1;-2")]
    [ExpectedException(ExpectedMessage = "negatives not allowed -2")]
    public void should_throw_exception_when_negative_numbers_are_passed2(string input)
    {
      StringCalc.Add(input);
    }

    [TestCase("2,1001", 2)]
    [TestCase("2,1002", 2)]
    [TestCase("2,1000", 1002)]
    public void When_a_number_is_greater_than_thousand_this_number_should_be_ignored(string input, int expectedSum)
    {
      var result = StringCalc.Add(input);

      Assert.AreEqual(expectedSum, result);
    }
  }
}
