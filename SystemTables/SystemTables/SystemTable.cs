using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTables
{
    public abstract class SystemTable<TKey, TVal> where TKey : IComparable
    {
        public abstract void Put(TKey key, TVal val);
        public abstract TVal Get(TKey key);
        public abstract bool Contains(TKey key);
        public abstract string GetName();
        public abstract TKey Floor(TKey key);
        public abstract int Size();
        public abstract int Rank(TKey key);
        public abstract void DeleteMin();
        public abstract void Delete(TKey key);
    }
}
