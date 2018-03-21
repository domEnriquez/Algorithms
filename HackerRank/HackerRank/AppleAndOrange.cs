using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestFixture]
    public class AppleAndOrange
    {
        [Test]
        public void canComputeScores()
        {
            Assert.AreEqual("0 0", countApplesAndOranges(7, 11, 5, 15, array(0), array(0)));
            Assert.AreEqual("0 0", countApplesAndOranges(7, 11, 5, 15, array(1), array(-1)));
            Assert.AreEqual("1 0", countApplesAndOranges(7, 11, 5, 15, array(2), array(-1)));
            Assert.AreEqual("0 0", countApplesAndOranges(9, 11, 5, 15, array(2), array(-1)));
            Assert.AreEqual("0 0", countApplesAndOranges(7, 11, 5, 15, array(10), array(-1)));
            Assert.AreEqual("2 0", countApplesAndOranges(7, 11, 5, 15, array(2,3), array(-1)));
            Assert.AreEqual("2 1", countApplesAndOranges(7, 11, 5, 15, array(2, 3), array(-4)));
            Assert.AreEqual("2 0", countApplesAndOranges(7, 11, 5, 15, array(2, 3), array(-10)));
            Assert.AreEqual("2 2", countApplesAndOranges(7, 11, 5, 15, array(2, 3), array(-4, -5)));
            Assert.AreEqual("1 1", countApplesAndOranges(-8, -5, -10, -1, array(3, 1), array(-5, 1)));
        }

        private int[] array(params int[] arr)
        {
            return arr;
        }

        private string countApplesAndOranges(int targetStartPos, int targetEndPos, int appleTreePos, 
                                                int orangeTreePos, int[] distsFromAppleTree, int[] distsFromOrangeTree)
        {
            int appleScore = calculateScore(targetStartPos, targetEndPos, appleTreePos, distsFromAppleTree);
            int orangeScore = calculateScore(targetStartPos, targetEndPos, orangeTreePos, distsFromOrangeTree);

            return appleScore.ToString() + " " + orangeScore.ToString();
        }

        private int calculateScore(int targetStartPos, int targetEndPos, int treePos, int[] distancesFromTree)
        {
            int score = 0;

            for (int i = 0; i < distancesFromTree.Length; i++)
                if (treePos + distancesFromTree[i] >= targetStartPos && treePos + distancesFromTree[i] <= targetEndPos)
                    score++;

            return score;
        }
    }
}
