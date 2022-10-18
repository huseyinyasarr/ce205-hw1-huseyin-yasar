using Microsoft.VisualStudio.TestTools.UnitTesting;
using mylibcs;
using System.Collections;

namespace ce205_hw1_csTest
{
    /// <summary>
    /// ///////////////////////////////////InfixEvaluate/////////////////////////////
    /// </summary>
    [TestClass]
    public class InfixEvaluate
    {
        [TestMethod]
        public void GoodCase()
        {
            int result = mylibcs.MyCalculator.evaluateInfix("(1 + 5) * (5 % (10 * 10))");
            Assert.AreEqual(500, result);
        }
        [TestMethod]
        public void BadCase()
        {
            int result = mylibcs.MyCalculator.evaluateInfix("(1 + 5) * (5 % (10 * 10))");
            Assert.AreNotEqual(550, result);
        }
        [TestMethod]
        public void UglyCase()
        {
            int result = mylibcs.MyCalculator.evaluateInfix("(1 + 5) * (5 % (10 * 10))");
            Assert.AreNotSame(500, result);
        }
    }
    /// <summary>
    /// //////////////////////////InfixValidate/////////////////////////////
    /// </summary>
    [TestClass]
    public class InfixValidate
    {
        [TestMethod]
        public void GoodCase()
        {
            ArrayList arr = new ArrayList();
            arr.Add("a+b*(c^d-e)^(f+g*h)-i");
            foreach (string s1 in arr)
            {
                string s = s1;
                s = "(" + s + ")";
                s = s.Replace(" ", string.Empty);
                bool result = MyCalculator.validateInfix(s) == true;
                Assert.AreEqual(false, result);
            }
        }
        [TestMethod]
        public void BadCase()
        {
            ArrayList arr = new ArrayList();
            arr.Add("a+b*(c^d-e)^(f+g*h)-i");
            foreach (string s1 in arr)
            {
                string s = s1;
                s = "(" + s + ")";
                s = s.Replace(" ", string.Empty);
                bool result = MyCalculator.validateInfix(s) == true;
                Assert.AreNotEqual(true, result);
            }
        }
        [TestMethod]
        public void UglyCase()
        {
            ArrayList arr = new ArrayList();
            arr.Add("a+b*(c^d-e)^(f+g*h)-i");
            foreach (string s1 in arr)
            {
                string s = s1;
                s = "(" + s + ")";
                s = s.Replace(" ", string.Empty);
                bool result = MyCalculator.validateInfix(s) == true;
                Assert.AreNotSame(true, result);
            }
        }
    }
    /// <summary>
    /// /////////////// InfixToPostfix TEST /////////////////////////////
    /// </summary>
    [TestClass]
    public class InfixToPostfix
    {
        [TestMethod]
        public void GoodCase()
        {
            string exp = "a+b*(c^d-e)^(f+g*h)-i";
            string result = "abcd^e-fgh*+^*+i-";
            Assert.AreEqual(MyCalculator.InfixToPostfixConversion(exp), result);
        }
        [TestMethod]
        public void BadCase()
        {
            string exp = "a+b*(c^d-e)^(f+g*h)-i";
            string result = "abcd^e-fgh*+*+i-";
            Assert.AreNotEqual(MyCalculator.InfixToPostfixConversion(exp), result);
        }
        [TestMethod]
        public void UglyCase()
        {
            string exp = "a+b*(c^d-e)^(f+g*h)-i";
            string result = "abcd^e-fgh*+*+i-";
            Assert.AreNotEqual(MyCalculator.InfixToPostfixConversion(exp), result);
        }
    }

}
