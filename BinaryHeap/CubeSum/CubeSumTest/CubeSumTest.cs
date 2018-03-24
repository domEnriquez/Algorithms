using ApprovalTests;
using ApprovalTests.Reporters;
using CubeSum;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace CubeSumTest
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class CubeSumTest
    {
        CubeSumBinaryHeap cs;
        StringBuilder fakeOutput;

        [SetUp]
        public void SetUp()
        {
            cs = new CubeSumBinaryHeap();
            fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));
        }

        [Test]
        public void showSortedCubeSumOf0()
        {
            cs.ShowCubeSums(0);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void showSortedCubeSumOf0To2()
        {
            cs.ShowCubeSums(2);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void showSortedCubeSumof0To5()
        {
            cs.ShowCubeSums(5);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void showSortedCubeSumof0to12()
        {
            cs.ShowCubeSums(12);

            Approvals.Verify(fakeOutput);
        }

        //All distinct integers a, b, c, and d between 0 and 10^6 such that a^3 + b^3 = c^3 + d^3
        [Test]
        public void showCubeSumsObtainedInTwoWays() 
        {
            cs.CubeSumsObtainedInTwoWays(12);

            Approvals.Verify(fakeOutput);
        }

        [Test]
        public void showCubeSumsObtainedInTwoWaysOf0To1000()
        {
            cs.CubeSumsObtainedInTwoWays(1000);

            Approvals.Verify(fakeOutput);
        }
    }
}
