using System;

namespace UnionFindApp
{
    public class UnionFind
    {
        int[] numbers;
        int limit;

        public UnionFind(int limit)
        {
            this.limit = limit;
            numbers = new int[limit];

            for (int i = 0; i < 10; i++)
                numbers[i] = i;
        }

        public void Union(int num1, int num2)
        {
            if (num1 > limit || num2 > limit)
                throw new NumberExceedsLimitException();

            int oldNum1Id = numbers[num1];
            numbers[num1] = numbers[num2];

            for(int i = 0; i < limit; i++)
                if (numbers[i] == oldNum1Id)
                    numbers[i] = numbers[num2];
        }

        public bool Connected(int num1, int num2)
        {
            if (num1 > limit || num2 > limit)
                throw new NumberExceedsLimitException();

            if (num1 == num2 || numbers[num1] == numbers[num2])
                return true;
            else
                return false;
        }

        public class NumberExceedsLimitException : Exception
        {

        }
    }
}
