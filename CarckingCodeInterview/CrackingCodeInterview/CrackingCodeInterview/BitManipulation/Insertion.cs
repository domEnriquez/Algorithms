using NUnit.Framework;

namespace CrackingCodeInterview.BitManipulation
{
    public class Insertion
    {
        public int Insert(int N, int M, int i, int j)
        {
            BitOperations bitOperations = new BitOperations();
            int mPos = 0;

            for(int k = i; k <= j; k++)
            {
                N = bitOperations.UpdateBit(N, k, bitOperations.GetBit(M, mPos++));
            }

            return N;
        }
        
    }

    [TestFixture]
    public class InsertionTest
    {
        [Test]
        public void canInsert()
        {
            Insertion ins = new Insertion();

            Assert.That(ins.Insert(9, 3, 1, 2), Is.EqualTo(15));
            Assert.That(ins.Insert(1024, 19, 2, 6), Is.EqualTo(1100));
        }
    }
}
