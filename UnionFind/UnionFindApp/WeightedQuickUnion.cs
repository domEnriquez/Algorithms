namespace UnionFindApp
{
    public class WeightedQuickUnion : UnionFind
    {
        private int[] size;

        public WeightedQuickUnion(int limit) : base(limit)
        {
            size = new int[limit];
        }

        public override bool Connected(int num1, int num2)
        {
            validateInput(num1, num2);

            if (num1 == num2)
                return true;
            else
            {
                if (root(num1) == root(num2))
                    return true;
                else
                    return false;
            }
        }

        public override void Union(int num1, int num2)
        {
            validateInput(num1, num2);

            int i = root(num1);
            int j = root(num2);

            if (i == j)
                return;

            if (size[i] < size[j])
            {
                numbers[i] = j;
                size[j] += size[i];
            }
            else
            {
                numbers[j] = i;
                size[i] += size[j];
            }
        }

        private int root(int num1)
        {
            while (numbers[num1] != num1)
                num1 = numbers[num1];

            return num1;
        }
    }
}
