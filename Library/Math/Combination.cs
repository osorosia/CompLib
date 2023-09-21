namespace CompLib
{
    public static partial class MathLib
    {
        public static long nCk(long n, long k, long mod = 0)
        {
            if (k < 0 || n < k)
                return 0;
            k = System.Math.Min(k, n - k);

            long ret = 1;
            for (long i = n; i > n - k; i--)
            {
                ret *= i;
                if (mod != 0)
                    ret %= mod;
            }

            long inv = 1;
            for (long i = 1; i <= k; i++)
            {
                inv *= i;
                if (mod != 0)
                    inv %= mod;
            }

            if (mod != 0)
                return (ret * ModInv(inv, mod)) % mod;
            else
                return ret / inv;
        }

        public static long nPk(long n, long k, long mod = 0)
        {
            if (k < 0 || n < k)
                return 0;

            long ret = 1;
            for (long i = n; i > n - k; i--)
            {
                ret *= i;
                if (mod > 0)
                    ret %= mod;
            }

            return ret;
        }

        public static long nHk(long n, long k, long mod = 0)
        {
            return nCk(n + k - 1, k, mod);
        }
    }
}
