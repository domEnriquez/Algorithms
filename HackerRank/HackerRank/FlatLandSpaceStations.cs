using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    [TestFixture]
    public class FlatLandSpaceStations
    {
        private int[] withStations(params int[] n)
        {
            return n;
        }

        [Test]
        public void canFindMaxDistance()
        {
            Assert.That(flatlandSpaceStations(1, withStations(0)), Is.EqualTo(0));
            Assert.That(flatlandSpaceStations(2, withStations(0)), Is.EqualTo(1));
            Assert.That(flatlandSpaceStations(2, withStations(0, 1)), Is.EqualTo(0));
            Assert.That(flatlandSpaceStations(3, withStations(0)), Is.EqualTo(2));
            Assert.That(flatlandSpaceStations(3, withStations(0, 1)), Is.EqualTo(1));
            Assert.That(flatlandSpaceStations(3, withStations(0, 1, 2)), Is.EqualTo(0));
            Assert.That(flatlandSpaceStations(5, withStations(0, 4)), Is.EqualTo(2));
            Assert.That(flatlandSpaceStations(95, 
                withStations(68, 81, 46, 54, 30, 11, 19, 23, 22, 12, 38, 91, 48, 75, 26, 86, 29, 83, 62)), Is.EqualTo(11));
        }

        private int flatlandSpaceStations(int n, int[] c)
        {
            Array.Sort(c);
            int maxDistance = c[0];

            for (int i = 1; i < c.Length; i++)
            {
                int distance = (c[i] - c[i - 1]) / 2;

                if (distance > maxDistance)
                    maxDistance = distance;
            }

            int lastDistance = (n - 1) - c[c.Length - 1];

            return (maxDistance > lastDistance) ? maxDistance : lastDistance;
        }

        private int flatlandSpaceStations_bruteForce(int n, int[] c)
        {
            if(n == 1 || n == c.Length)
                return 0;

            int distance = Int32.MaxValue;
            List<int> distances = new List<int>();

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < c.Length; j++)
                {
                    int currDistance = Math.Abs(i - c[j]);

                    if (currDistance == 0)
                    {
                        distance = currDistance;
                        break;
                    }

                    if(currDistance < distance)
                    {
                        distance = currDistance;
                    }

                }

                distances.Add(distance);
                distance = Int32.MaxValue;
            }

            return distances.Max();
        }
    }
}
