using Xunit;
using CompLib.DataStructure;

namespace CompLib.Test.DataStructure
{
    public class UnionFindTest
    {
        [Fact]
        public void UnionFind_Test()
        {
            var uf = new UnionFind(10);

            uf.Merge(0, 1);
            uf.Merge(0, 2);
            uf.Merge(2, 3);
            uf.Merge(4, 5);

            Assert.True(uf.Same(0, 1));
            Assert.True(uf.Same(0, 2));
            Assert.True(uf.Same(0, 3));
            Assert.True(uf.Same(4, 5));

            Assert.False(uf.Same(0, 4));
        }
    }
}
