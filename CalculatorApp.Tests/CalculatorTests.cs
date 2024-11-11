namespace CalculatorApp.Tests;

using NUnit.Framework;
using CalculatorApp;
using CalculatorApp.Helpers;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
       // Instantiate dependencies
        var parser = new Parser();
        
        // Pass dependencies to Calculator
        _calculator = new Calculator(parser);
    }

    [Test]
    public void Add_WithSingleNumber_ReturnsSameNumber()
    {
        var result = _calculator.Add("20");
        Assert.That(result, Is.EqualTo(20));
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
    public void Add_WithMoreThanTwoNumbers_ReturnsCorrectSum()
    {
        var result = _calculator.Add("1,2,3,4,5,6,7,8,9,10,11,12");
        Assert.That(result, Is.EqualTo(78));
    }

    [Test]
    public void Add_WithNewlineAndCommaDelimiters_ReturnsSum()
    {
        var input = "1\n2,3";
        var result = _calculator.Add(input);
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void Add_WithNegativeNumbers_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.Add("2,-3,-1,5"));
    }
    
    [Test]
    public void Add_WithNumberGreaterThan1000_IgnoresNumber()
    {
        var result = _calculator.Add("2,1001,6");
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Add_WithCustomDelimiter_ReturnsSum()
    {
        var input = "//#\n2#5";
        var result = _calculator.Add(input);
        Assert.That(result, Is.EqualTo(7));
    }
    
    [Test]
    public void Add_WithCustomDelimiterSecondExample_ReturnsSum()
    {
        var input = "//,\n2,ff,100";
        var result = _calculator.Add(input);
        Assert.That(result, Is.EqualTo(102));
    }

    [Test]
    public void Add_WithSingleMultiCharacterDelimiter_ReturnsSum()
    {
        var input = "//[***]\n1***2***3";
        var result = _calculator.Add(input);
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Add_WithMultipleDelimitersOfAnyLength_ReturnsSum()
    {
        var input = "//[*][!!][r9r]\n11r9r22*hh*33!!44";
        var result = _calculator.Add(input);
        Assert.That(result, Is.EqualTo(110));
    }

    // This test was working before step 2
    // [Test]
    // public void Add_WithMoreThanTwoNumbers_ThrowsException()
    // {
    //     Assert.Throws<ArgumentException>(() => _calculator.Add("1,2,3"));
    // }

    // This test was working before step 5
    // [Test]
    // public void Add_WithTwoNumbers_ReturnsSum()
    // {
    //     var result = _calculator.Add("1,5000");
    //     Assert.That(result, Is.EqualTo(5001));
    // }

    // This test was working before step 4
    // [Test]
    // public void Add_WithNegativeNumber_ReturnsCorrectSum()
    // {
    //     var result = _calculator.Add("4,-3");
    //     Assert.That(result, Is.EqualTo(1));
    // }
}