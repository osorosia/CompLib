using System;

namespace CompLib.DataStructure
{
    public enum SegmentTreeType
    {
        RmQ,
        // RMQ,
        // RSQ,
        // RAQ,
    }

    public class SegmentTree
    {
        private int _OriginSize;
        private int _N;
        private long[] _Array;

        public SegmentTree(SegmentTreeType type, long[] arr)
        {
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
                    : long.MaxValue;
            }

            for (var i = _N - 2; i >= 0; i--)
            {
                _Array[i] = Math.Min(_Array[ToLeftChild(i)], _Array[ToRightChild(i)]);
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
                _Array[i] = Math.Min(_Array[ToLeftChild(i)], _Array[ToRightChild(i)]);
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
            if (r <= left || right <= l) return long.MaxValue;
            if (left <= l && r <= right) return _Array[k];

            var vl = QueryHelper(left, right, k * 2 + 1, l, (l + r) / 2);
            var vr = QueryHelper(left, right, k * 2 + 2, (l + r) / 2, r);
            return Math.Min(vl, vr);
        }

        private int ToParent(int i) => (i - 1) / 2;

        private int ToLeftChild(int i) => i * 2 + 1;

        private int ToRightChild(int i) => i * 2 + 2;
    }
}
