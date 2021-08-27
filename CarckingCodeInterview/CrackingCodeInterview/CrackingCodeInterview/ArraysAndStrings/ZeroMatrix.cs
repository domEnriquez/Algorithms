using NUnit.Framework;
using System.Collections.Generic;

namespace CrackingCodeInterview
{
    [TestFixture]
    public class ZeroMatrix
    {
        [Test]
        public void zeroMatrixTest()
        {
            Assert.That(zeroMatrix(new int[,] { { 1, 2 }, { 3, 0 } }), 
                Is.EquivalentTo(new int[,] { {1,0},{0,0} }));
            Assert.That(zeroMatrix(new int[,] { { 1, 0, 4 }, { 5, 6, 7 } }), 
                Is.EquivalentTo(new int[,] { { 0, 0, 0 }, { 5, 0, 7 } }));
            Assert.That(zeroMatrix(new int[,] { { 1, 2, 3, 4 }, { 5, 0, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 0, 16 } }),
                Is.EquivalentTo(new int[,] { { 1, 0, 0, 4 }, { 0, 0, 0, 0 }, { 9, 0, 0, 12 }, { 0, 0, 0, 0 } }));
        }

        public int[,] zeroMatrix(int [,] array2D)
        {
            int rows = array2D.GetLength(0);
            int cols = array2D.GetLength(1);
            List<int> colToSkip = new List<int>();

            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (colToSkip.Contains(j))
                        continue;

                    if(array2D[i, j] == 0)
                    {
                        setToZero(array2D, i, j);
                        colToSkip.Add(j);
                        break;
                    }
                }
            }

            return array2D;
        }

        private void setToZero(int[,] array2D, int row, int col)
        {
            int rowSize = array2D.GetLength(0);
            int colSize = array2D.GetLength(1);

            for(int i = 0; i < colSize; i++)
                array2D[row, i] = 0;

            for (int j = 0; j < rowSize; j++)
                array2D[j, col] = 0;
        }
    }
}
