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

            // Merge
            Assert.True(uf.Merge(0, 1));
            Assert.True(uf.Merge(0, 2));
            Assert.True(uf.Merge(2, 3));
            Assert.True(uf.Merge(4, 5));

            Assert.False(uf.Merge(0, 1));

            // Same
            Assert.True(uf.Same(0, 1));
            Assert.True(uf.Same(0, 2));
            Assert.True(uf.Same(0, 3));
            Assert.True(uf.Same(4, 5));

            Assert.False(uf.Same(0, 4));
        }
    }
}