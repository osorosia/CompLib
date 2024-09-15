namespace Library.Test.Algorithm;

public class PermutationTest
{
    [Fact]
    public void Permutation_Test()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var permutation = new Permutation<int>(list);

        Assert.Equal(new List<int> { 1, 2, 3, 4 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 1, 2, 4, 3 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 1, 3, 2, 4 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 1, 3, 4, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 1, 4, 2, 3 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 1, 4, 3, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 1, 3, 4 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 1, 4, 3 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 3, 1, 4 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 3, 4, 1 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 4, 1, 3 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 4, 3, 1 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 3, 1, 2, 4 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 3, 1, 4, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 3, 2, 1, 4 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 3, 2, 4, 1 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 3, 4, 1, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 3, 4, 2, 1 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 4, 1, 2, 3 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 4, 1, 3, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 4, 2, 1, 3 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 4, 2, 3, 1 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 4, 3, 1, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 4, 3, 2, 1 }, permutation.Current());
        Assert.False(permutation.Next());
    }

    [Fact]
    public void Permutation_Test_2()
    {
        var list = new List<int> { 3, 2, 1 };
        var permutation = new Permutation<int>(list);

        Assert.Equal(new List<int> { 3, 2, 1 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 3, 1, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 3, 1 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 1, 3 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 1, 3, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 1, 2, 3 }, permutation.Current());
        Assert.False(permutation.Next());
    }

    [Fact]
    public void Permutation_Test_3()
    {
        var list = new List<int> { 1, 2 };
        var permutation = new Permutation<int>(list);

        Assert.Equal(new List<int> { 1, 2 }, permutation.Current());
        Assert.True(permutation.Next());
        Assert.Equal(new List<int> { 2, 1 }, permutation.Current());
        Assert.False(permutation.Next());
    }

    [Fact]
    public void Permutation_Test_4()
    {
        var list = new List<int> { 1 };
        var permutation = new Permutation<int>(list);

        Assert.Equal(new List<int> { 1 }, permutation.Current());
        Assert.False(permutation.Next());
    }   
}
