namespace CompLib.Test.DataStructure;

public class SegmentTreeTest
{
    [Fact]
    public void SegmentTree_RmQ_Test()
    {
        {
            // 10 11 12 13 14
            var st = new SegmentTree(SegmentTreeType.RmQ, new long[] { 10, 11, 12, 13, 14 });
            Assert.Equal(
                new long[] { 10, 11, 12, 13, 14 },
                new[] { st[0], st[1], st[2], st[3], st[4] }
            );

            Assert.Equal(10, st.Query(0, 1));
            Assert.Equal(10, st.Query(0, 2));
            Assert.Equal(10, st.Query(0, 3));
            Assert.Equal(10, st.Query(0, 4));
            Assert.Equal(10, st.Query(0, 5));

            Assert.Equal(10, st.Query(0, 5));
            Assert.Equal(11, st.Query(1, 5));
            Assert.Equal(12, st.Query(2, 5));
            Assert.Equal(13, st.Query(3, 5));
            Assert.Equal(14, st.Query(4, 5));

            Assert.Equal(11, st.Query(1, 2));
            Assert.Equal(12, st.Query(2, 3));
            Assert.Equal(13, st.Query(3, 4));
            Assert.Equal(14, st.Query(4, 5));
        }

        {
            // 10 11 12 13
            var st = new SegmentTree(SegmentTreeType.RmQ, new long[] { 10, 11, 12, 13 });
            Assert.Equal(
                new long[] { 10, 11, 12, 13 },
                new[] { st[0], st[1], st[2], st[3] }
            );

            Assert.Equal(10, st.Query(0, 1));
            Assert.Equal(10, st.Query(0, 2));
            Assert.Equal(10, st.Query(0, 3));
            Assert.Equal(10, st.Query(0, 4));

            Assert.Equal(11, st.Query(1, 2));
            Assert.Equal(12, st.Query(2, 3));
            Assert.Equal(13, st.Query(3, 4));

            // 10 11 12 -1
            st[3] = -1;
            Assert.Equal(
                new long[] { 10, 11, 12, -1 },
                new[] { st[0], st[1], st[2], st[3] }
            );

            Assert.Equal(-1, st.Query(0, 4));
            Assert.Equal(-1, st.Query(1, 4));
            Assert.Equal(-1, st.Query(2, 4));
            Assert.Equal(-1, st.Query(3, 4));

            Assert.Equal(10, st.Query(0, 1));
            Assert.Equal(10, st.Query(0, 2));
            Assert.Equal(10, st.Query(0, 3));

            // 10 11 12 13
            st[3] = 13;
            Assert.Equal(
                new long[] { 10, 11, 12, 13 },
                new[] { st[0], st[1], st[2], st[3] }
            );

            Assert.Equal(10, st.Query(0, 1));
            Assert.Equal(10, st.Query(0, 2));
            Assert.Equal(10, st.Query(0, 3));
            Assert.Equal(10, st.Query(0, 4));

            Assert.Equal(11, st.Query(1, 2));
            Assert.Equal(12, st.Query(2, 3));
            Assert.Equal(13, st.Query(3, 4));
        }
    }

    [Fact]
    public void SegmentTree_RMQ_Test()
    {
        {
            // 10 11 12 13 14
            var st = new SegmentTree(SegmentTreeType.RMQ, new long[] { 10, 11, 12, 13, 14 });
            Assert.Equal(
                new long[] { 10, 11, 12, 13, 14 },
                new[] { st[0], st[1], st[2], st[3], st[4] }
            );

            Assert.Equal(10, st.Query(0, 1));
            Assert.Equal(11, st.Query(0, 2));
            Assert.Equal(12, st.Query(0, 3));
            Assert.Equal(13, st.Query(0, 4));
            Assert.Equal(14, st.Query(0, 5));

            Assert.Equal(14, st.Query(0, 5));
            Assert.Equal(14, st.Query(1, 5));
            Assert.Equal(14, st.Query(2, 5));
            Assert.Equal(14, st.Query(3, 5));
            Assert.Equal(14, st.Query(4, 5));

            Assert.Equal(11, st.Query(1, 2));
            Assert.Equal(12, st.Query(2, 3));
            Assert.Equal(13, st.Query(3, 4));
            Assert.Equal(14, st.Query(4, 5));
        }
    }
}
