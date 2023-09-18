namespace CompLib.Test.String;

public class ZAlgorithmTest
{
    [Fact]
    public void ZAlgorithm_Test()
    {
        {
            var s = "ababab";
            var z = ZAlgorithm(s);
            Assert.Equal(new[] { 6, 0, 4, 0, 2, 0 }, z);
        }

        {
            var s = "aaaaaa";
            var z = ZAlgorithm(s);
            Assert.Equal(new[] { 6, 5, 4, 3, 2, 1 }, z);
        }
    }
}
