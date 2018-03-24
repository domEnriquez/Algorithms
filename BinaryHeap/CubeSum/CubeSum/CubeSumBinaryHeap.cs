using GenericStack;
using PriorityQueues;
using System;
using System.Text;

namespace CubeSum
{
    public class CubeSumBinaryHeap
    {
        BinaryHeapMinPQ<CubeSum> bh;

        public CubeSumBinaryHeap()
        {
            bh = new BinaryHeapMinPQ<CubeSum>();
        }

        public void ShowCubeSums(int limit)
        {
            for (int i = 0; i <= limit; i++)
                bh.Insert(new CubeSum(i,0)); 

            while(!bh.IsEmpty())
            {
                CubeSum smallest = bh.DeleteTop();
                Console.WriteLine(smallest);

                if (smallest.J < limit)
                    bh.Insert(new CubeSum(smallest.I, smallest.J + 1));
            }
        }

        public void CubeSumsObtainedInTwoWays(int limit)
        {
            for (int i = 0; i <= limit; i++)
                bh.Insert(new CubeSum(i, 0));

            CubeSum prev = null;
            int displayedSum = 0;
            while (!bh.IsEmpty())
            {
                CubeSum smallest = bh.DeleteTop();

                if(prev == null)
                    prev = smallest;

                if (prev.Sum == smallest.Sum && distinctAddends(prev, smallest) && smallest.Sum != displayedSum)
                {
                    Console.WriteLine(prev);
                    Console.WriteLine(smallest);
                    displayedSum = prev.Sum;
                    prev = null;                    
                }
                else
                    prev = smallest;

                if (smallest.J < limit)
                    bh.Insert(new CubeSum(smallest.I, smallest.J + 1));
            }
        }

        private static bool distinctAddends(CubeSum prev, CubeSum smallest)
        {
            return prev.I != smallest.I 
                    && prev.I != smallest.J 
                    && prev.J != smallest.J 
                    && prev.J != smallest.I;
        }

        private class CubeSum : IComparable
        {
            public int Sum { get; set; }
            public int I { get; set; }
            public int J { get; set; }

            public CubeSum(int i, int j)
            {
                I = i;
                J = j;
                Sum = I * I * I + J * J * J;
            }

            public int CompareTo(object obj)
            {
                CubeSum other = (CubeSum)obj;

                if (Sum > other.Sum)
                    return 1;
                else if (Sum < other.Sum)
                    return -1;
                else
                    return 0;
            }

            public override string ToString()
            {
                return string.Format("{0} = {1}^3 + {2}^3", Sum, I, J);
            }
        }
    }
}
