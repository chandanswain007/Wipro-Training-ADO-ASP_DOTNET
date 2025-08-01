using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Practice_assignment1;

[TestClass]
public class CalculatorTests
{
    private readonly Calculator _calculator = new Calculator();

    [TestMethod]
    public void Add_ValidInputs_ReturnsCorrectSum()
    {
        // Arrange
        double a = 5;
        double b = 10;

        // Act
        double result = _calculator.Add(a, b);

        // Assert
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Subtract_ValidInputs_ReturnsCorrectDifference()
    {
        // Arrange
        double a = 10;
        double b = 5;

        // Act
        double result = _calculator.Subtract(a, b);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Multiply_ValidInputs_ReturnsCorrectProduct()
    {
        // Arrange
        double a = 5;
        double b = 10;

        // Act
        double result = _calculator.Multiply(a, b);

        // Assert
        Assert.AreEqual(50, result);
    }

    [TestMethod]
    public void Divide_ValidInputs_ReturnsCorrectQuotient()
    {
        // Arrange
        double a = 10;
        double b = 5;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Divide_ByZero_ThrowsArgumentException()
    {
        // Arrange
        double a = 10;
        double b = 0;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => _calculator.Divide(a, b));
    }

    [TestMethod]
    public void Add_ZeroToNumber_ReturnsNumber()
    {
        // Arrange
        double a = 15;
        double b = 0;

        // Act
        double result = _calculator.Add(a, b);

        // Assert
        Assert.AreEqual(15, result);
    }
}
