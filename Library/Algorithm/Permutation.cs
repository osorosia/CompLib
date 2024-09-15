namespace CompLib.Algorithm;

public class Permutation<T>
{
    private readonly List<T> _List;
    private readonly List<int> _Indexes;

    public Permutation(IEnumerable<T> list)
    {
        _List = list.ToList();
        _Indexes = Enumerable.Range(0, _List.Count).ToList();
    }

    public List<T> Current()
    {
        return _List;
    }

    // 次の順列を_Listに格納する
    // 次の順列がない場合はfalseを返す
    public bool Next()
    {
        if (_Indexes.Count == 0)
        {
            return false;
        }

        // 末尾から見て降順がどこまで続いているか
        int i = _Indexes.Count - 2;
        while (i >= 0 && _Indexes[i] >= _Indexes[i + 1])
        {
            i--;
        }

        if (i < 0)
        {
            return false;
        }

        // _Indexes[i]の次に大きい要素を探す
        int j = _Indexes.Count - 1;
        while (_Indexes[j] <= _Indexes[i])
        {
            j--;
        }

        Swap(i, j);
        Reverse(i + 1, _Indexes.Count - 1);

        return true;
    }

    private void Swap(int i, int j)
    {
        (_List[i], _List[j]) = (_List[j], _List[i]);
        (_Indexes[i], _Indexes[j]) = (_Indexes[j], _Indexes[i]);
    }

    private void Reverse(int i, int j)
    {
        while (i < j)
        {
            Swap(i, j);
            i++;
            j--;
        }
    }
}
