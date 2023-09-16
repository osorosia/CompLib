namespace CompLib.DataStructure
{
    public class UnionFind
    {
        private int[] _Parents;
        private int[] _Size;
        private int _N;

        public UnionFind(int n)
        {
            _Parents = new int[n];
            _Size = new int[n];
            _N = n;

            for (int i = 0; i < n; i++)
            {
                _Size[i] = 1;
                _Parents[i] = i;
            }
        }

        public bool IsSame(int x, int y)
        {
            return Find(x) == Find(y);
        }

        public bool Merge(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x == y) return false;

            if (_Size[x] < _Size[y])
            {
                (x, y) = (y, x);
            }

            _Size[x] += _Size[y];
            _Parents[y] = x;

            return true;
        }

        public int[] Roots()
        {
            return _Parents.Distinct().OrderBy(x => x).ToArray();
        }

        public Dictionary<int, int[]> Groups()
        {
            var dic = Enumerable.Range(0, _N)
                .Select(i => (Index: i, Parent: Find(i)))
                .GroupBy(p => p.Parent, p => p.Index)
                .ToDictionary(g => g.Key, g => g.ToArray());

            return dic;
        }

        private int Find(int x)
        {
            if (x == _Parents[x])
                return x;
            _Parents[x] = Find(_Parents[x]);
            return _Parents[x];
        }
    }
}
