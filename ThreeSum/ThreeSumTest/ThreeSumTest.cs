using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeSum;

namespace ThreeSumTest
{
    [TestFixture]
    public class ThreeSumTest
    {
        private List<AbstractThreeSum> ts;
        
        [SetUp]
        public void Setup()
        {
            int[] numArray = new int[] { -20, -40, 0, -10, 10, 5, 40, 30 };
            ts = new List<AbstractThreeSum>() { new BruteForceThreeSum(numArray), new FastThreeSum(numArray) };
        }

        [Test]
        public void canFindThreeNumsWhichSumIsZero()
        {
            for(int i = 0; i < ts.Count; i++)
                Assert.AreEqual(4, ts[i].Count());
        }
    }
}
