using System;

namespace UnionFindApp
{
    public abstract class UnionFind
    {
        protected int[] numbers;
        protected int limit;

        public UnionFind(int limit)
        {
            this.limit = limit;
            numbers = new int[limit];

            for (int i = 0; i < 10; i++)
                numbers[i] = i;
        }

        public abstract void Union(int num1, int num2);

        public abstract bool Connected(int num1, int num2);

        protected void validateInput(int num1, int num2)
        {
            if (num1 > limit || num2 > limit)
                throw new NumberExceedsLimitException();
        }

        public class NumberExceedsLimitException : Exception
        {

        }
    }
}
