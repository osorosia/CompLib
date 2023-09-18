namespace CompLib
{
    public static partial class String
    {
        public static int[] ZAlgorithm(string s)
        {
            var z = new int[s.Length];
            z[0] = s.Length;

            int i = 1, j = 0;
            while (i < s.Length)
            {
                while (i + j < s.Length && s[j] == s[i + j])
                {
                    j++;
                }
                z[i] = j;

                if (j == 0)
                {
                    i++;
                    continue;
                }
                int k = 1;
                while (k < j && k + z[k] < j)
                {
                    z[i + k] = z[k];
                    k++;
                }
                i += k;
                j -= k;
            }
            return z;
        }
    }
}
