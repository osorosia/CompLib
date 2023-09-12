using System;

namespace CompLib.DataStructure
{
    public class UnionFind
    {
        long[] _parent;
        long[] _size;
        long _n;

        public UnionFind(long n)
        {
            _parent = new long[n];
            _size = new long[n];
            _n = n;
            for (long i = 0; i < n; i++)
            {
                _size[i] = 1;
                _parent[i] = i;
            }
        }

        public long Find(long x)
        {
            if (x == _parent[x])
                return x;
            _parent[x] = Find(_parent[x]);
            return _parent[x];
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
            if (_size[x] < _size[y])
                (x, y) = (y, x);
            _size[x] += _size[y];
            _parent[y] = x;
            return true;
        }

        public List<long> Roots()
        {
            var st = new SortedSet<long>();
            for (int i = 0; i < _n; i++)
                st.Add(Find(i));

            var ls = new List<long>();
            foreach (var s in st)
                ls.Add(s);

            return ls;
        }

        public SortedDictionary<long, List<long>> Groups()
        {
            var mp = new SortedDictionary<long, List<long>>();

            for (long i = 0; i < _n; i++)
            {
                Find(i);
                if (!mp.ContainsKey(_parent[i]))
                    mp.Add(_parent[i], new List<long>());
                mp[_parent[i]].Add(i);
            }

            return mp;
        }
    }
}
