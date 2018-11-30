using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM_exam_calc;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVM_exam_calc_Tests
{
    [TestClass]
    public class CalModelViewTests
    {
        [TestMethod]
        public void CanModelViewInititiate()
        {
            CalcModelView modelView = new CalcModelView();
        }

        [TestMethod]
        public void CanInputNumber1()
        {
            CalcModelView modelView = new CalcModelView();

            modelView.InputNumberOne = 1;

            Assert.AreEqual(1, modelView.InputNumberOne);
        }

        [TestMethod]
        public void CanInputNumber2()
        {
            CalcModelView modelView = new CalcModelView();

            modelView.InputNumberTwo = 2;

            Assert.AreEqual(2, modelView.InputNumberTwo);
        }

        [TestMethod]
        public void CanOutputResult()
        {
            CalcModelView modelView = new CalcModelView();

            modelView.Result = 3;

            Assert.AreEqual(3, modelView.Result);
        }

        [TestMethod]
        public void CanCalc_OnePlusOne()
        {
            CalcModelView modelView = new CalcModelView();

            ICommand command = modelView.CalcCommand;

            modelView.InputNumberOne = 1;
            modelView.InputNumberTwo = 1;

            command.Execute(null);

            Assert.AreEqual(2, modelView.Result);
        }

        [TestMethod]
        public void CanCalc_TwoPlusTwo()
        {
            CalcModelView modelView = new CalcModelView();

            ICommand command = modelView.CalcCommand;

            modelView.InputNumberOne = 2;
            modelView.InputNumberTwo = 2;

            command.Execute(null);

            Assert.AreEqual(4, modelView.Result);
        }


        [TestMethod]
        public void CanCalc_ResultChanged()
        {
            bool hasFired = false;

            CalcModelView modelView = new CalcModelView();
            modelView.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Result")
                    hasFired = true;
            };

            modelView.InputNumberOne = 3;
            modelView.InputNumberTwo = 3;

            ICommand command = modelView.CalcCommand;
            command.Execute(null);
            
            Assert.IsTrue(hasFired);
        }
    }
}
