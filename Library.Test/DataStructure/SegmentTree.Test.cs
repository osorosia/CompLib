using Xunit;
using CompLib.DataStructure;

namespace CompLib.Test.DataStructure;

public class SegmentTreeTest
{
    [Fact]
    public void SegmentTree_RmQ_Test()
    {
        {
            // 0 1 2 3 4
            var st = new SegmentTree(new long[] { 0, 1, 2, 3, 4 });

            Assert.Equal(0, st.Query(0, 1));
            Assert.Equal(0, st.Query(0, 2));
            Assert.Equal(0, st.Query(0, 3));
            Assert.Equal(0, st.Query(0, 4));
            Assert.Equal(0, st.Query(0, 5));

            Assert.Equal(1, st.Query(1, 2));
            Assert.Equal(2, st.Query(2, 3));
            Assert.Equal(3, st.Query(3, 4));
            Assert.Equal(4, st.Query(4, 5));
        }

        {
            // 0 1 2 3
            var st = new SegmentTree(new long[] { 0, 1, 2, 3 });

            Assert.Equal(0, st.Query(0, 1));
            Assert.Equal(0, st.Query(0, 2));
            Assert.Equal(0, st.Query(0, 3));
            Assert.Equal(0, st.Query(0, 4));

            Assert.Equal(1, st.Query(1, 2));
            Assert.Equal(2, st.Query(2, 3));
            Assert.Equal(3, st.Query(3, 4));

            // 0 1 2 -1
            st.Update(3, -1);

            Assert.Equal(-1, st.Query(0, 4));
            Assert.Equal(-1, st.Query(1, 4));
            Assert.Equal(-1, st.Query(2, 4));
            Assert.Equal(-1, st.Query(3, 4));

            Assert.Equal(0, st.Query(0, 1));
            Assert.Equal(0, st.Query(0, 2));
            Assert.Equal(0, st.Query(0, 3));
        }
    }
}
