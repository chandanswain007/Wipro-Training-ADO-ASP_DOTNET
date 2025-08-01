using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo_Calculator_app;

namespace MathLibrary.MSTest
{
    [TestClass]
    public sealed class Test1
    {
        private Calculator calculates = null!; // Suppress null warning; guaranteed initialized in Setup

        [TestInitialize]
        public void Setup()
        {
            calculates = new Calculator();
        }

        [TestMethod]
        public void Add_ReturnSum()
        {
            int result = calculates.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Subtract_ReturnDifference()
        {
            int result = calculates.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Multiply_ReturnProduct()
        {
            int result = calculates.Multiply(4, 5);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Divide_ReturnQuotient()
        {
            double result = calculates.Divide(10, 2);
            Assert.AreEqual(5.0, result, 0.001); // 0.001 tolerance for floating point comparison
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ThrowsException()
        {
            calculates.Divide(10, 0);
        }
    }
}