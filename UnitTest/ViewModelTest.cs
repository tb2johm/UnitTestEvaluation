using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UnitTestEvalualtion.Model;
using UnitTestEvalualtion.ViewModel;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest
{
    [TestClass]
    public class ViewModelTest
    {
        private ViewModel _vm;
        
        [SetUp]
        public void SetupViewModel()
        {
            _vm = new ViewModel();
        }

        [TestCase("23","512", "+", true, "535")]
        [TestCase("", "512", "+", false, "")]
        [TestCase("23", "512", "-", true, "-489")]
        public void TestCalculate(string a, string b, string c, bool canExec, string result)
        {
            _vm.VarA = a;
            _vm.VarB = b;
            _vm.Calculus = c;

            Assert.AreEqual(canExec, _vm.CalculateCommand.CanExecute(null));

            if (!canExec) return;

            _vm.CalculateCommand.Execute(null);
            Assert.AreEqual(result, _vm.Result);
        }
    }

    [TestClass]
    public class ViewModelTestMocks
    {
        [Test]
        public void TestCalculateWithMock()
        {
            var _vm = new ViewModel(new ModelMock());

            _vm.VarA = "34";
            _vm.VarB = "32";
            _vm.Calculus = "+";

            Assert.AreEqual(true, _vm.CalculateCommand.CanExecute(null));

            _vm.CalculateCommand.Execute(null);
            Assert.AreEqual("66", _vm.Result);
        }
    }

    public class ModelMock : IModel
    {
        public string Add(string a, string b)
        {
            return (double.Parse(a) + double.Parse(b)).ToString();
        }

        public string Sub(string a, string b)
        {
            throw new System.NotImplementedException();
        }

        public bool Validate(string a, string b)
        {
            double tmp;
            if (!double.TryParse(a, out tmp)) return false;
            if (!double.TryParse(b, out tmp)) return false;

            return true;
        }
    }
}
