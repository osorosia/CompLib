namespace CompLib.Test.DataStructure;

public class LazySegmentTreeTest
{
    [Fact]
    public void LazySegmentTree_RmQ_Test()
    {
        {
            // 10 11 12 13 14
            var tree = new LazySegmentTree(LazySegmentTreeType.RmQ, new long[] { 10, 11, 12, 13, 14 });
            Assert.Equal(
                new long[] { 10, 11, 12, 13, 14 },
                new[] { tree[0], tree[1], tree[2], tree[3], tree[4] }
            );

            Assert.Equal(10, tree.Query(0, 1));
            Assert.Equal(10, tree.Query(0, 2));
            Assert.Equal(10, tree.Query(0, 3));
            Assert.Equal(10, tree.Query(0, 4));
            Assert.Equal(10, tree.Query(0, 5));

            Assert.Equal(10, tree.Query(0, 5));
            Assert.Equal(11, tree.Query(1, 5));
            Assert.Equal(12, tree.Query(2, 5));
            Assert.Equal(13, tree.Query(3, 5));
            Assert.Equal(14, tree.Query(4, 5));

            Assert.Equal(11, tree.Query(1, 2));
            Assert.Equal(12, tree.Query(2, 3));
            Assert.Equal(13, tree.Query(3, 4));
            Assert.Equal(14, tree.Query(4, 5));
        }
    }
}
