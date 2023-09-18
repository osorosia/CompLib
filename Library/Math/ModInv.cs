namespace CompLib
{
    public static partial class Math
    {
        public static long ModInv(long x, long mod)
        {
            return ModPow(x, mod - 2, mod);
        }
    }
}
