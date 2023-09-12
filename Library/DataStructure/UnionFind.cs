using System;

namespace CompLib.DataStructure
{
    public class UnionFind
    {
        long[] parent;
        long[] size;
        long N;

        public UnionFind(long n)
        {
            parent = new long[n];
            size = new long[n];
            N = n;
            for (long i = 0; i < n; i++)
            {
                size[i] = 1;
                parent[i] = i;
            }
        }

        public long Find(long x)
        {
            if (x == parent[x])
                return x;
            parent[x] = Find(parent[x]);
            return parent[x];
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
            if (size[x] < size[y])
                (x, y) = (y, x);
            size[x] += size[y];
            parent[y] = x;
            return true;
        }

        public List<long> Roots()
        {
            var st = new SortedSet<long>();
            for (int i = 0; i < N; i++)
                st.Add(Find(i));

            var ls = new List<long>();
            foreach (var s in st)
                ls.Add(s);

            return ls;
        }

        public SortedDictionary<long, List<long>> Groups()
        {
            var mp = new SortedDictionary<long, List<long>>();
            for (long i = 0; i < N; i++)
            {
                Find(i);
                if (!mp.ContainsKey(parent[i]))
                    mp.Add(parent[i], new List<long>());
                mp[parent[i]].Add(i);
            }
            return mp;
        }
    }
}
