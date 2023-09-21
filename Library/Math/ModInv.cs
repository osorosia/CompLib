namespace CompLib
{
    public static partial class MathLib
    {
        public static long ModInv(long x, long mod)
        {
            return ModPow(x, mod - 2, mod);
        }
    }
}
