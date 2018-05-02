using ArithmeticEvaluator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticEvaluatorTest
{
    [TestFixture]
    public class ArithmeticEvaluatorTest
    {
        [Test]
        public void AcceptanceTest()
        {
            TwoStackAlgorithm eval = new TwoStackAlgorithm();

            Assert.AreEqual(101.0, eval.Evaluate("(1+((2+3)*(4*5)))"));
        }
    }
}
