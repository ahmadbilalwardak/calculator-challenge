namespace CalculatorApp.Tests;

using NUnit.Framework;
using CalculatorApp;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_WithSingleNumber_ReturnsSameNumber()
    {
        var result = _calculator.Add("20");
        Assert.That(result, Is.EqualTo(20));
    }

    [Test]
    public void Add_WithTwoNumbers_ReturnsSum()
    {
        var result = _calculator.Add("1,5000");
        Assert.That(result, Is.EqualTo(5001));
    }

    [Test]
    public void Add_WithNegativeNumber_ReturnsCorrectSum()
    {
        var result = _calculator.Add("4,-3");
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Add_WithEmptyInput_ReturnsZero()
    {
        var result = _calculator.Add("");
        // Assert.AreEqual(0, result);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Add_WithInvalidNumber_ReturnsZeroForInvalid()
    {
        var result = _calculator.Add("5,tytyt");
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Add_WithMoreThanTwoNumbers_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.Add("1,2,3"));
    }
}