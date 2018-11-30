using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM_exam_calc;

namespace MVVM_exam_calc_Tests
{
    [TestClass]
    public class CalculatorTests
    {
        Calc calc;

        [TestInitialize]
        public void Setup()
        {
            calc = new Calc();
        }

        [DataRow(0, 0, 0)]
        [DataRow(1, 1, 2)]
        [DataRow(2, 1, 3)]
        [DataTestMethod]
        public void CanSum_Zero_plus_Zero(int num1, int num2, int expected)
        {
            Assert.AreEqual(expected, actual: calc.sum(num1, num2));
        }
    }
}
