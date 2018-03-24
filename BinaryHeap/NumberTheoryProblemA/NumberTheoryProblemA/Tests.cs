using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheoryProblemA
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class Tests
    {
        StringBuilder fakeOutput;
        EquationSolution es;

        [SetUp]
        public void SetUp()
        {
            es = new EquationSolution();
            fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));
        }

        [Test]
        public void numLimitIs0()
        {
            es.FindSolution(0);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void numLimitIs1()
        {
            es.FindSolution(1);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void numLimitIs2()
        {
            es.FindSolution(2);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void numLimitis9K()
        {
            es.FindSolution(9000);

            Approvals.Verify(fakeOutput);
        }
    }
}
