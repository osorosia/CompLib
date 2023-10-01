namespace CompLib.DataStructure
{
    public enum LazySegmentTreeType
    {
        RmQ, // Range Minimum Query
        // RMQ, // Range Maximum Query
        // RSQ, // Range Sum Query
        // RAQ,
    }

    public class LazySegmentTree
    {
        private int _OriginSize;
        private int _N;
        private long[] _Array;
        private long[] _Lazy;
        private long _Identity;

        private Func<long, long, long> Combine;

        private (long, Func<long, long, long>) Config(LazySegmentTreeType type)
        {
            return type switch
            {
                LazySegmentTreeType.RmQ => (long.MaxValue, System.Math.Min),
                // LazySegmentTreeType.RMQ => (long.MinValue, System.Math.Max),
                // LazySegmentTreeType.RSQ => (0, (x, y) => x + y),
                _ => throw new NotImplementedException(),
            };
        }

        public LazySegmentTree(LazySegmentTreeType type, long[] arr)
        {
            var (identity, combine) = Config(type);

            _Identity = identity;
            Combine = combine;

            _OriginSize = arr.Length;

            var n = 1;
            while (n < arr.Length) n *= 2;

            _N = n;
            _Array = new long[2 * _N - 1];
            _Lazy = new long[2 * _N - 1];

            for (var i = 0; i < _Lazy.Length; i++)
            {
                _Lazy[i] = _Identity;
            }

            for (var i = _N - 1; i < _Array.Length; i++)
            {
                var arrIdx = i - (_N - 1);

                _Array[i] = arrIdx < arr.Length
                    ? arr[arrIdx]
                    : _Identity;
            }

            for (var i = _N - 2; i >= 0; i--)
            {
                _Array[i] = Combine(_Array[ToLeftChild(i)], _Array[ToRightChild(i)]);
            }
        }

        public long this[int i]
        {
            get => Query(i, i + 1);
            set => Update(i, i + 1, value);
        }

        public void Update(int left, int right, long x)
        {
            UpdateHelper(left, right, x, 0, 0, _N);

            void UpdateHelper(int left, int right, long x, int k, int l, int r)
            {
                Eval(k);
                if (left <= l && r <= right)
                {
                    _Lazy[k] = x;
                    Eval(k);
                }
                else if (left < r && l < right)
                {
                    UpdateHelper(left, right, x, ToLeftChild(k), l, (l + r) / 2);
                    UpdateHelper(left, right, x, ToRightChild(k), (l + r) / 2, r);
                    _Array[k] = Combine(_Array[ToLeftChild(k)], _Array[ToRightChild(k)]);
                }
            }
        }

        public long Query(int left, int right)
        {
            return QueryHelper(left, right, 0, 0, _N);

            long QueryHelper(int left, int right, int k, int l, int r)
            {
                Eval(k);
                if (right <= l || r <= left) return _Identity;
                if (left <= l && r <= right) return _Array[k];

                var vl = QueryHelper(left, right, ToLeftChild(k), l, (l + r) / 2);
                var vr = QueryHelper(left, right, ToRightChild(k), (l + r) / 2, r);
                return Combine(vl, vr);
            }
        }

        private void Eval(int k)
        {
            if (_Lazy[k] == _Identity) return;

            if (k < _N - 1)
            {
                _Lazy[ToLeftChild(k)] += _Lazy[k];
                _Lazy[ToRightChild(k)] += _Lazy[k];
            }

            _Array[k] = _Lazy[k];
            _Lazy[k] = _Identity;
        }

        private int ToParent(int i) => (i - 1) / 2;

        private int ToLeftChild(int i) => i * 2 + 1;

        private int ToRightChild(int i) => i * 2 + 2;
    }
}
