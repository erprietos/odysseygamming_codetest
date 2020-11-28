using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void expression_withoutoperator_returnerror()
        {
            // Arrange
            string expression = "22222\r";
            var expected = "incorrect expression!. missing operators";
            string result = "";

            // Act
            CalcEngine calcEngine = new CalcEngine();
            result = calcEngine.Process(expression);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void expression_withmoreoperatorsthannumbers_returnerror()
        {
            // Arrange
            string expression = "22222++-\r";
            var expected = "incorrect expression!!";
            string result = "";

            // Act
            CalcEngine calcEngine = new CalcEngine();
            result = calcEngine.Process(expression);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void totals_usingmultplevalues_returnerror()
        {
            // Arrange
            string expression = "10+10+20-40\r";
            var expected = "0";
            string result = "";

            // Act
            CalcEngine calcEngine = new CalcEngine();
            result = calcEngine.Process(expression);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void totals_usingmultiplevalues_returncorrecttotal()
        {
            // Arrange
            string expression = "10+10+20-40\r";
            var expected = "0";
            string result = "";

            // Act
            CalcEngine calcEngine = new CalcEngine();
            result = calcEngine.Process(expression);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void totals_usingdecimalvalues_returncorrecttotal()
        {
            // Arrange
            string expression = "1.1+1.1\r";
            var expected = "2.2";
            string result = "";

            // Act
            CalcEngine calcEngine = new CalcEngine();
            result = calcEngine.Process(expression);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void totals_usingcombinationsvalues_returncorrecttotal()
        {
            // Arrange
            string expression = "1.1+1.1+2+2\r";
            var expected = "6.2";
            string result = "";

            // Act
            CalcEngine calcEngine = new CalcEngine();
            result = calcEngine.Process(expression);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
