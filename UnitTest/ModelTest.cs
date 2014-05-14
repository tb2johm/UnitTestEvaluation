using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UnitTestEvalualtion.Model;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest
{
    [TestClass]
    public class ModelTest
    {
        private Model _myModel;

        [SetUp]
        public void Setup()
        {
            _myModel = new Model();
        }

        [TestMethod]
        public void TestAdd()
        {
            var a = "2";

            var r = _myModel.Add(a, a);
            
            Assert.AreEqual("4", r);
        }

        [TestMethod]
        public void TestSub()
        {
            var a = "2";

            var r = _myModel.Sub(a, a);

            Assert.AreEqual("0", r);
        }

        [TestCase("23", "34", true)]
        [TestCase("2,3", "232", true)]
        [TestCase("2.3", "232", false)]
        [TestCase(null, "34", false)]
        [TestCase("asdf", "adc", false)]
        [TestCase("23", "0x32", false)]
        public void TestValidate(string a, string b, bool expectTrue)
        {
            var r = _myModel.Validate(a, b);
            
            if (expectTrue)
                Assert.IsTrue(r);
            else
                Assert.IsFalse(r);
        }
    }
}
