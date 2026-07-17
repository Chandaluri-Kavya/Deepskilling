using CalcLibrary;
using NUnit.Framework;

namespace CalculatorTests;

[TestFixture]
public class CalculatorTests
{
    private Calculator? _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [TearDown]
    public void TearDown()
    {
        _calculator = null;
    }

    [Test]
    [TestCase(1, 2, 3)]
    [TestCase(-1, 5, 4)]
    [TestCase(0, 0, 0)]
    public void Add_ReturnsExpectedResult(int a, int b, int expected)
    {
        Assert.That(_calculator!.Add(a, b), Is.EqualTo(expected));
    }

    [Test]
    [Ignore("Demonstration of ignored tests for requirements")]
    public void IgnoredTestExample()
    {
        Assert.Fail("This test is ignored and should not run.");
    }
}
