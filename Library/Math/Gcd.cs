namespace CompLib
{
    public static partial class MathLib
    {
        public static long Gcd(long a, long b)
        {
            if (a < b) (a, b) = (b, a);
            if (b == 0) return a;
            return Gcd(b, a % b);
        }
    }
}
