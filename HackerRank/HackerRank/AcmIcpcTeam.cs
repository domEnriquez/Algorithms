using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class AcmIcpcTeam
    {
        private string[] arrayStr(params string[] n)
        {
            return n;
        }

        private int[] arrayInt(params int[] n)
        {
            return n;
        }

        private void assertAcmTeam(string[] topic, int[] expected, string comment)
        {
            Assert.AreEqual(expected, acmTeam(topic), comment);
        }

        [Test]
        public void canCountAcmTeam()
        {
            assertAcmTeam(arrayStr(), arrayInt(0, 0), "1");
            assertAcmTeam(arrayStr("00", "00"), arrayInt(0, 0), "2");
            assertAcmTeam(arrayStr("10", "00"), arrayInt(1, 1), "3");
            assertAcmTeam(arrayStr("10", "10"), arrayInt(1, 1), "4");
            assertAcmTeam(arrayStr("111", "111"), arrayInt(3, 1), "5");
            assertAcmTeam(arrayStr("111", "111", "111"), arrayInt(3, 3), "6");
            assertAcmTeam(arrayStr("10101", "11110", "00010"), arrayInt(5, 1), "7");
            assertAcmTeam(arrayStr("10101", "11100", "11010", "00101"), arrayInt(5, 2), "7");

        }

        private int[] acmTeam(string[] topic)
        {
            if(topic == null || topic.Length == 0)
                return new int[] { 0, 0 };

            int largestTopicCount = 0;
            int teamCount = 0;

            for (int i = 0; i < topic.Length - 1; i++)
            {
                string first = topic[i];

                for(int k = i+1; k < topic.Length; k++ )
                {
                    string sec = topic[k];

                    int topicCount = 0;

                    for (int j = 0; j < first.Length; j++)
                        if (first[j] == '1' || sec[j] == '1')
                            topicCount++;

                    if (topicCount == largestTopicCount)
                        teamCount++;
                    else if (topicCount > largestTopicCount)
                    {
                        teamCount = 1;
                        largestTopicCount = topicCount;
                    }
                }

            }

            if(largestTopicCount > 0)
                return new int[] { largestTopicCount, teamCount };
            else
                return new int[] { 0, 0 };
        }
    }
}
