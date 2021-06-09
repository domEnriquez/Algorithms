using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HackerRank
{
    [TestFixture]
    public class CavityMap
    {
        [Test]
        public void canDetectCavities()
        {
            Assert.That(cavityMap(new List<string> { "1" }), 
                Is.EqualTo(new List<string> { "1" }));

            Assert.That(cavityMap(new List<string> { "11", "11" }), 
                Is.EqualTo(new List<string> { "11", "11" }));

            Assert.That(cavityMap(new List<string> { "111", "121", "111" }), 
                Is.EqualTo(new List<string> { "111", "1X1", "111" }));

            Assert.That(cavityMap(new List<string> { "111", "111", "111" }),
                Is.EqualTo(new List<string> { "111", "111", "111" }));

            Assert.That(cavityMap(new List<string> { "1111", "1211", "1121", "1111" }),
                Is.EqualTo(new List<string> { "1111", "1X11", "11X1", "1111" }));

            Assert.That(cavityMap(new List<string> { "1112", "1912", "1892", "1234" }),
                Is.EqualTo(new List<string> { "1112", "1X12", "18X2", "1234" }));

        }

        private List<string> cavityMap(List<string> grid)
        {
            if(grid.Count < 3)
                return grid;

            for (int i = 1; i < grid.Count - 1; i++)
            {
                for(int j = 1; j < grid[i].Length - 1; j ++)
                {
                    if(!allInts(grid, i , j))
                    {
                        continue;
                    }

                    int target = int.Parse(grid[i][j].ToString());
                    int left = int.Parse(grid[i][j - 1].ToString());
                    int right = int.Parse(grid[i][j + 1].ToString());
                    int top = int.Parse(grid[i - 1][j].ToString());
                    int bottom = int.Parse(grid[i + 1][j].ToString());

                    if (target > left && target > right && target > top && target > bottom)
                    {
                        grid[i] = grid[i].Remove(j, 1).Insert(j, "X");
                    }

                }
            }

            return grid;
        }

        private bool allInts(List<string> grid, int i, int j)
        {
            if (!Char.IsDigit(grid[i][j])) return false;
            if (!Char.IsDigit(grid[i][j - 1])) return false;
            if (!Char.IsDigit(grid[i][j + 1])) return false;
            if (!Char.IsDigit(grid[i-1][j])) return false;
            if (!Char.IsDigit(grid[i + 1][j])) return false;

            return true;
        }
    }
}
