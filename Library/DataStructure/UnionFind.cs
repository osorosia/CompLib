using System;

namespace CompLib.DataStructure
{
    public class UnionFind
    {
        private long[] _Parent;
        private long[] _Size;
        private long _N;

        public UnionFind(long n)
        {
            _Parent = new long[n];
            _Size = new long[n];
            _N = n;
            for (long i = 0; i < n; i++)
            {
                _Size[i] = 1;
                _Parent[i] = i;
            }
        }

        public bool Same(long x, long y)
        {
            return Find(x) == Find(y);
        }

        public bool Merge(long x, long y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y)
                return false;
            if (_Size[x] < _Size[y])
                (x, y) = (y, x);
            _Size[x] += _Size[y];
            _Parent[y] = x;
            return true;
        }

        public List<long> Roots()
        {
            var st = new SortedSet<long>();
            for (int i = 0; i < _N; i++)
                st.Add(Find(i));

            var ls = new List<long>();
            foreach (var s in st)
                ls.Add(s);

            return ls;
        }

        public SortedDictionary<long, List<long>> Groups()
        {
            var mp = new SortedDictionary<long, List<long>>();

            for (long i = 0; i < _N; i++)
            {
                Find(i);
                if (!mp.ContainsKey(_Parent[i]))
                    mp.Add(_Parent[i], new List<long>());
                mp[_Parent[i]].Add(i);
            }

            return mp;
        }

        private long Find(long x)
        {
            if (x == _Parent[x])
                return x;
            _Parent[x] = Find(_Parent[x]);
            return _Parent[x];
        }
    }
}
