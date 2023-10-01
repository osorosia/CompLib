namespace CompLib.Util
{
    public class BitFlag
    {
        public static bool Has(long bitFlag, int i)
        {
            return (bitFlag & (1L << i)) != 0;
        }
    }
}
