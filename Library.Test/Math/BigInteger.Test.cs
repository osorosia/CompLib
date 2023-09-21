namespace CompLib.Test.Math;

public class BigIntegerTest
{
    [Fact]
    public void BigInteger_Add_Test()
    {
        var str = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        var expectedStr = "12345678901234567890123456789012345678901234567890123456789012345678901234567891";

        var a = System.Numerics.BigInteger.Parse(str) + 1;
        Assert.Equal(expectedStr, a.ToString());
    }

    [Fact]
    public void BigInteger_Sub_Test()
    {
        var str = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        var expectedStr = "12345678901234567890123456789012345678901234567890123456789012345678901234567889";

        var a = System.Numerics.BigInteger.Parse(str) - 1;
        Assert.Equal(expectedStr, a.ToString());
    }

    [Fact]
    public void BigInteger_Mul_Test()
    {
        var str = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        var expectedStr = "123456789012345678901234567890123456789012345678901234567890123456789012345678900";

        var a = System.Numerics.BigInteger.Parse(str) * 10;
        Assert.Equal(expectedStr, a.ToString());
    }

    [Fact]
    public void BigInteger_Div_Test()
    {
        var str = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        var expectedStr = "1234567890123456789012345678901234567890123456789012345678901234567890123456789";

        var a = System.Numerics.BigInteger.Parse(str) / 10;
        Assert.Equal(expectedStr, a.ToString());
    }
}
