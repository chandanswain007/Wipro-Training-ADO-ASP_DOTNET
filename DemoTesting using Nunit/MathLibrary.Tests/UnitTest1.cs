//imorting Nunit framework and our application
using NUnit.Framework;
using DemoTesting_using_Nunit;  // added this as reference
namespace MathLibrary.Tests
{
    public class calculatorTests
    {
        private Calculator calculator;
        [SetUp]  // attributes
        public void Setup()
        {
            calculator = new Calculator();  // allocating memory using 'new'
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            //Assert.Pass();  for passing flow of execution
            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            //Assert.Pass();  for passing flow of execution
            int result = calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }
        [Test]
        public void Multiply_ShouldReturnCorrectMultiplication()
        {
            //Assert.Pass();  for passing flow of execution
            int result = calculator.Multiply(2, 3);
            Assert.AreEqual(6, result);
        }
        [Test]
        public void Divide_ShouldReturnCorrectDivision()
        {
            //Assert.Pass();  for passing flow of execution
            int result = Convert.ToInt32(calculator.Divide(6, 3));
            Assert.AreEqual(2, result);
        }
    }
}