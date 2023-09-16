namespace CompLib.DataStructure
{
    public enum SegmentTreeType
    {
        RmQ, // Range Minimum Query
        RMQ, // Range Maximum Query
        RSQ, // Range Sum Query
        // RAQ,
    }

    public class SegmentTree
    {
        private int _OriginSize;
        private int _N;
        private long[] _Array;
        private long _Identity;

        private Func<long, long, long> Combine;

        private (long, Func<long, long, long>) Config(SegmentTreeType type)
        {
            return type switch
            {
                SegmentTreeType.RmQ => (long.MaxValue, Math.Min),
                SegmentTreeType.RMQ => (long.MinValue, Math.Max),
                SegmentTreeType.RSQ => (0, (x, y) => x + y),
                _ => throw new NotImplementedException(),
            };
        }

        public SegmentTree(SegmentTreeType type, long[] arr)
        {
            var (identity, combine) = Config(type);

            _Identity = identity;
            Combine = combine;

            _OriginSize = arr.Length;

            var n = 1;
            while (n < arr.Length) n *= 2;

            _N = n;
            _Array = new long[2 * _N - 1];

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
            get => _Array[i + _N - 1];
            set => Update(i, value);
        }

        /// <summary>
        /// Update value at index i to x.
        /// </summary>
        public void Update(int i, long x)
        {
            if (i < 0 || _OriginSize <= i) throw new IndexOutOfRangeException();

            i += _N - 1;

            _Array[i] = x;

            while (i > 0)
            {
                i = ToParent(i);
                _Array[i] = Combine(_Array[ToLeftChild(i)], _Array[ToRightChild(i)]);
            }
        }

        /// <summary>
        /// Get min value over the range [left, right).
        /// </summary>
        public long Query(int left, int right)
        {
            if (left < 0 || _OriginSize < left) throw new IndexOutOfRangeException();
            if (right < 0 || _OriginSize < right) throw new IndexOutOfRangeException();
            if (left >= right) throw new IndexOutOfRangeException();

            return QueryHelper(left, right, 0, 0, _N);
        }

        private long QueryHelper(int left, int right, int k, int l, int r)
        {
            if (r <= left || right <= l) return _Identity;
            if (left <= l && r <= right) return _Array[k];

            var vl = QueryHelper(left, right, k * 2 + 1, l, (l + r) / 2);
            var vr = QueryHelper(left, right, k * 2 + 2, (l + r) / 2, r);
            return Combine(vl, vr);
        }

        private int ToParent(int i) => (i - 1) / 2;

        private int ToLeftChild(int i) => i * 2 + 1;

        private int ToRightChild(int i) => i * 2 + 2;
    }
}
