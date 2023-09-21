namespace CompLib
{
    public static partial class MathLib
    {
        public static long Lcm(long a, long b)
        {
            return a / Gcd(a, b) * b;
        }

        public static long Lcm(long[] a)
        {
            long l = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                l = Lcm(l, a[i]);
            }
            return l;
        }
    }
}
