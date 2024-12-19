namespace ValidParenthesesTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Example1()
        {
            Assert.IsTrue(ValidParentheses.Validate.input("()"));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.IsTrue(ValidParentheses.Validate.input("()[]{}"));
        }

        [TestMethod]
        public void Example3()
        {
            Assert.IsFalse(ValidParentheses.Validate.input("(]"));
        }

        [TestMethod]
        public void Example4()
        {
            Assert.IsFalse(ValidParentheses.Validate.input("([)]"));
        }

        [TestMethod]
        public void Example5()
        {
            Assert.IsTrue(ValidParentheses.Validate.input("{[]}"));
        }
    }
}