// Interval Heap
// https://natsugiri.hatenablog.com/entry/2016/10/10/035445
namespace CompLib.DataStructure
{
    public class PriorityQueue<T>
    {
        List<(long key, T data)> _Heap;
        Func<T, long> _Func;

        public PriorityQueue(Func<T, long> f)
        {
            _Heap = new List<(long key, T data)>();
            _Func = f;
        }

        public void Push(T x)
        {
            _Heap.Add((_Func(x), x));
            Up(_Heap.Count - 1);
        }

        public bool Any() => _Heap.Count > 0;

        public int Count() => _Heap.Count;

        public T GetMax() => _Heap[0].data;

        public T GetMin() => _Heap.Count >= 2 ? _Heap[1].data : _Heap[0].data;

        public T PopMax()
        {
            if (_Heap.Count == 0) throw new System.IndexOutOfRangeException();

            var ret = GetMax();

            if (_Heap.Count < 2)
            {
                _Heap.RemoveAt(_Heap.Count - 1);
            }
            else
            {
                (_Heap[0], _Heap[_Heap.Count - 1]) = (_Heap[_Heap.Count - 1], _Heap[0]);
                _Heap.RemoveAt(_Heap.Count - 1);
                var k = Down(0);
                Up(k);
            }

            return ret;
        }

        public T PopMin()
        {
            if (_Heap.Count == 0) throw new System.IndexOutOfRangeException();

            var ret = GetMin();

            if (_Heap.Count < 3)
            {
                _Heap.RemoveAt(_Heap.Count - 1);
            }
            else
            {
                (_Heap[1], _Heap[_Heap.Count - 1]) = (_Heap[_Heap.Count - 1], _Heap[1]);
                _Heap.RemoveAt(_Heap.Count - 1);
                var k = Down(1);
                Up(k);
            }

            return ret;
        }

        private void MakeHeap()
        {
            for (int i = _Heap.Count; i >= 0; i--)
            {
                if ((i & 1) != 0 && _Heap[i - 1].key < _Heap[i].key)
                {
                    (_Heap[i - 1], _Heap[i]) = (_Heap[i], _Heap[i - 1]);
                }
                int k = Down(i);
                Up(k, i);
            }
        }

        private int Up(int k, int root = 1)
        {
            if ((k | 1) < _Heap.Count && _Heap[k & ~1].key < _Heap[k | 1].key)
            {
                (_Heap[k & ~1], _Heap[k | 1]) = (_Heap[k | 1], _Heap[k & ~1]);
                k ^= 1;
            }

            int p;
            // max _Heap
            while (root < k && _Heap[p = Parent(k)].key < _Heap[k].key)
            {
                (_Heap[p], _Heap[k]) = (_Heap[k], _Heap[p]);
                k = p;
            }
            // min _Heap
            while (root < k && _Heap[p = Parent(k) | 1].key > _Heap[k].key)
            {
                (_Heap[p], _Heap[k]) = (_Heap[k], _Heap[p]);
                k = p;
            }
            return k;
        }

        private int Down(int k)
        {
            int n = _Heap.Count;

            // min _Heap
            if ((k & 1) != 0)
            {
                while (2 * k + 1 < n)
                {
                    int c = 2 * k + 3;
                    if (c >= n || _Heap[c - 2].key < _Heap[c].key)
                    {
                        c -= 2;
                    }

                    if (c < n && _Heap[c].key < _Heap[k].key)
                    {
                        (_Heap[c], _Heap[k]) = (_Heap[k], _Heap[c]);
                        k = c;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            // max _Heap
            else
            {
                while (2 * k + 2 < n)
                {
                    int c = 2 * k + 4;
                    if (c >= n || _Heap[c - 2].key > _Heap[c].key)
                    {
                        c -= 2;
                    }

                    if (c < n && _Heap[c].key > _Heap[k].key)
                    {
                        (_Heap[c], _Heap[k]) = (_Heap[k], _Heap[c]);
                        k = c;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return k;
        }

        private int Parent(int k)
        {
            return ((k >> 1) - 1) & ~1;
        }
    }
}
