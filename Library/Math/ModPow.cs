namespace CompLib
{
    public static partial class Math
    {
        public static long ModPow(long x, long n, long mod = 0)
        {
            long ret = 1;
            while (n > 0)
            {
                if ((n & 1) != 0)
                {
                    ret *= x;
                    if (mod != 0)
                        ret %= mod;
                }
                x *= x;
                if (mod != 0)
                    x %= mod;
                n >>= 1;
            }
            return ret;
        }
    }
}
