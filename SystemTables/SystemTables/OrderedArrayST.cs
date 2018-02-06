using System;

namespace SystemTables
{
    public class OrderedArrayST<TKey, TVal> : SystemTable<TKey, TVal> where TKey : IComparable
    {
        private TKey[] keys;
        private TVal[] values;
        private int N = 0;

        public OrderedArrayST()
        {
            keys = new TKey[1];
            values = new TVal[1];
        }
        public override void Put(TKey key, TVal val)
        {
            if (N == keys.Length)
                resize(2 * keys.Length);

            putInOrder(key, val);
        }

        private void putInOrder(TKey key, TVal val)
        {
            int r = Rank(key);

            if(r < N && key.CompareTo(keys[r]) == 0)
            {
                putIn(r, key, val);
            }
            else
            {
                shiftThenPut(r, key, val);
                N++;
            }
        }

        private void shiftThenPut(int i, TKey key, TVal val)
        {
            shiftRight(i);
            putIn(i, key, val);
        }

        private void putIn(int i, TKey key, TVal val)
        {
            keys[i] = key;
            values[i] = val;
        }

        private void shiftRight(int startIndex)
        {
            for(int i = N - 1; i >= startIndex; i--)
            {
                keys[i + 1] = keys[i];
                values[i + 1] = values[i];
            }
        }

        private void resize(int capacity)
        {
            TKey[] copyKeys = new TKey[capacity];
            TVal[] copyVal = new TVal[capacity];

            for(int i = 0; i < N; i++)
            {
                copyKeys[i] = keys[i];
                copyVal[i] = values[i];
            }

            keys = copyKeys;
            values = copyVal;
        }

        public override bool Contains(TKey key)
        {
            throw new NotImplementedException();
        }

        public override TVal Get(TKey key)
        {
            int i = Rank(key);

            if (i < N && key.CompareTo(keys[i]) == 0)
                return values[i];

            return default(TVal);
        }

        public override int Rank(TKey key)
        {
            int low = 0;
            int high = N-1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (key.CompareTo(keys[mid]) < 0)
                    high = mid - 1;
                else if (key.CompareTo(keys[mid]) > 0)
                    low = mid + 1;
                else
                    return mid;
            }

            return low;
        }

        public override string GetName()
        {
            return "OrderedArrayST";
        }

        public override TKey Floor(TKey key)
        {
            int r = Rank(key);

            if (r < N && key.CompareTo(keys[r]) == 0)
                return key;
            else if (r > 0)
                return keys[r - 1];
            else
                return default(TKey);
        }

        public override int Size()
        {
            return N;
        }

        public override void DeleteMin()
        {
            N--;
            shiftLeft(0);
        }

        private void shiftLeft(int startIndex)
        {
            for (int i = startIndex; i < N; i++)
            {
                keys[i] = keys[i + 1];
                values[i] = values[i + 1];
            }

        }

        public override void Delete(TKey key)
        {
            N--;
            shiftLeft(Rank(key));
        }
    }
}
