namespace CompLib.Test.DataStructure;

public class PriorityQueueTest
{
    [Fact]
    public void PriorityQueue_Long_Test()
    {
        {
            var pq = new PriorityQueue<long>(x => x);

            var arr = new[] { 1, 2, 3, 4, 5 };
            foreach (var i in arr) pq.Push(i);

            Assert.Equal(5, pq.PopMax());
            Assert.Equal(4, pq.PopMax());
            Assert.Equal(3, pq.PopMax());
            Assert.Equal(2, pq.PopMax());
            Assert.Equal(1, pq.PopMax());
            Assert.False(pq.Any());

            foreach (var i in arr) pq.Push(i);
            Assert.Equal(1, pq.PopMin());
            Assert.Equal(2, pq.PopMin());
            Assert.Equal(3, pq.PopMin());
            Assert.Equal(4, pq.PopMin());
            Assert.Equal(5, pq.PopMin());
            Assert.False(pq.Any());

            foreach (var i in arr.Reverse()) pq.Push(i);

            Assert.Equal(5, pq.PopMax());
            Assert.Equal(4, pq.PopMax());
            Assert.Equal(3, pq.PopMax());
            Assert.Equal(2, pq.PopMax());
            Assert.Equal(1, pq.PopMax());
            Assert.False(pq.Any());

            foreach (var i in arr.Reverse()) pq.Push(i);
            Assert.Equal(1, pq.PopMin());
            Assert.Equal(2, pq.PopMin());
            Assert.Equal(3, pq.PopMin());
            Assert.Equal(4, pq.PopMin());
            Assert.Equal(5, pq.PopMin());
            Assert.False(pq.Any());
        }
    }
}
