namespace UnionFindApp
{
    public class QuickUnion : UnionFind
    {
        public QuickUnion(int limit) : base(limit)
        {
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

            numbers[root(num1)] = root(num2);
        }

        private int root(int num1)
        {
            while (numbers[num1] != num1)
                num1 = numbers[num1];

            return num1;
        }
    }
}
