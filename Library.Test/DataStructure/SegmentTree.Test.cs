namespace CompLib.Test.DataStructure;

public class SegmentTreeTest
{
    [Fact]
    public void SegmentTree_RmQ_Test()
    {
        {
            // 10 11 12 13 14
            var tree = new SegmentTree(SegmentTreeType.RmQ, new long[] { 10, 11, 12, 13, 14 });
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

        {
            // 10 11 12 13
            var tree = new SegmentTree(SegmentTreeType.RmQ, new long[] { 10, 11, 12, 13 });
            Assert.Equal(
                new long[] { 10, 11, 12, 13 },
                new[] { tree[0], tree[1], tree[2], tree[3] }
            );

            Assert.Equal(10, tree.Query(0, 1));
            Assert.Equal(10, tree.Query(0, 2));
            Assert.Equal(10, tree.Query(0, 3));
            Assert.Equal(10, tree.Query(0, 4));

            Assert.Equal(11, tree.Query(1, 2));
            Assert.Equal(12, tree.Query(2, 3));
            Assert.Equal(13, tree.Query(3, 4));

            // 10 11 12 -1
            tree[3] = -1;
            Assert.Equal(
                new long[] { 10, 11, 12, -1 },
                new[] { tree[0], tree[1], tree[2], tree[3] }
            );

            Assert.Equal(-1, tree.Query(0, 4));
            Assert.Equal(-1, tree.Query(1, 4));
            Assert.Equal(-1, tree.Query(2, 4));
            Assert.Equal(-1, tree.Query(3, 4));

            Assert.Equal(10, tree.Query(0, 1));
            Assert.Equal(10, tree.Query(0, 2));
            Assert.Equal(10, tree.Query(0, 3));

            // 10 11 12 13
            tree[3] = 13;
            Assert.Equal(
                new long[] { 10, 11, 12, 13 },
                new[] { tree[0], tree[1], tree[2], tree[3] }
            );

            Assert.Equal(10, tree.Query(0, 1));
            Assert.Equal(10, tree.Query(0, 2));
            Assert.Equal(10, tree.Query(0, 3));
            Assert.Equal(10, tree.Query(0, 4));

            Assert.Equal(11, tree.Query(1, 2));
            Assert.Equal(12, tree.Query(2, 3));
            Assert.Equal(13, tree.Query(3, 4));
        }
    }

    [Fact]
    public void SegmentTree_RMQ_Test()
    {
        {
            // 10 11 12 13 14
            var tree = new SegmentTree(SegmentTreeType.RMQ, new long[] { 10, 11, 12, 13, 14 });
            Assert.Equal(
                new long[] { 10, 11, 12, 13, 14 },
                new[] { tree[0], tree[1], tree[2], tree[3], tree[4] }
            );

            Assert.Equal(10, tree.Query(0, 1));
            Assert.Equal(11, tree.Query(0, 2));
            Assert.Equal(12, tree.Query(0, 3));
            Assert.Equal(13, tree.Query(0, 4));
            Assert.Equal(14, tree.Query(0, 5));

            Assert.Equal(14, tree.Query(0, 5));
            Assert.Equal(14, tree.Query(1, 5));
            Assert.Equal(14, tree.Query(2, 5));
            Assert.Equal(14, tree.Query(3, 5));
            Assert.Equal(14, tree.Query(4, 5));

            Assert.Equal(11, tree.Query(1, 2));
            Assert.Equal(12, tree.Query(2, 3));
            Assert.Equal(13, tree.Query(3, 4));
            Assert.Equal(14, tree.Query(4, 5));
        }
    }
}
