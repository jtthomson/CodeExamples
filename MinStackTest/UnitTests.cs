using System.Diagnostics;
using System.Text;

namespace MinStackTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ExampleTestCase()
        {
            string inputSets = @"[""MinStack"",""push"",""push"",""push"",""getMin"",""pop"",""top"",""getMin""]";
            string inputVals = @"[[],[-2],[0],[-3],[],[],[],[]]";

            Stack.MinStack minStack = Stack.MinStack.MinStackFactory(inputSets, inputVals);
            Assert.AreEqual(minStack.run(), "[null,null,null,null,-3,null,0,-2]");
        }

        [TestMethod]
        public void MaxValsTestCase()
        {
            string inputSets = @"[""MinStack"",""push"",""push"",""push"",""getMin"",""pop"",""top"",""getMin""]";
            string inputVals = @$"[[],[{int.MaxValue}],[{int.MaxValue - 1}],[{int.MinValue}],[],[],[],[]]";

            Stack.MinStack minStack = Stack.MinStack.MinStackFactory(inputSets, inputVals);
            Assert.AreEqual(minStack.run(), $"[null,null,null,null,{int.MinValue},null,{int.MaxValue - 1},{int.MaxValue - 1}]");
        }

        [TestMethod]
        public void SetsNotMatchValsTestCase()
        {
            string inputSets = @"[""MinStack"",""push"",""push"",""getMin"",""pop"",""top"",""getMin""]";
            string inputVals = @$"[[],[-2],[0],[-3],[],[],[],[]]";

            Assert.ThrowsException<DataMisalignedException>(() => Stack.MinStack.MinStackFactory(inputSets, inputVals), "Number of Sets must be equal to the number of vals");
        }

        [TestMethod]
        public void nullPushTestCase()
        {
            string inputSets = @"[""MinStack"",""push"",""push"",""push"",""getMin"",""pop"",""top"",""getMin""]";
            string inputVals = @"[[],[-2],[0],[],[],[],[],[]]";

            Stack.MinStack minStack = Stack.MinStack.MinStackFactory(inputSets, inputVals);
            Assert.ThrowsException<InvalidOperationException>(() => minStack.run(), "Nullable object must have a value.");
        }

        [TestMethod]
        public void LoadTestCase()
        {
            int threashold = 30;//milliseconds

            StringBuilder setSb = new StringBuilder();
            StringBuilder valSb = new StringBuilder();
            setSb.Append("[\"MinStack\",\"push\",");
            valSb.Append("[[], [-2],");
            for (int i = 0; i < 30000 - 3; i++)
            {
                setSb.Append("\"push\",");
                valSb.Append("[0],");
            }
            setSb.Append("\"getMin\"]");
            valSb.Append("[]]");
            string inputSets = setSb.ToString();
            string inputVals = valSb.ToString();
            var timer = Stopwatch.StartNew(); 
            Stack.MinStack minStack = Stack.MinStack.MinStackFactory(inputSets, inputVals);
            string result = minStack.run();
            timer.Stop();
            Assert.AreEqual(result.Count(), 149999);//correct string
            Assert.AreEqual(result.Substring(result.Length - 3), "-2]");//minValue in constant time
            Assert.IsTrue(timer.ElapsedMilliseconds <= threashold);//efficient process time
        }
    }
}