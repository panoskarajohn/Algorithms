using FluentAssertions;
using Problems.Heap;

namespace Problem.Tests.Heap;

public class MedianFinderInStreamTests
{
    [Fact]
    public void Median_Finder_In_Stream_Tests()
    {
        var median = new MedianFinder();
        median.AddNum(1);
        median.AddNum(2);
        median.FindMedian().Should().Be(1.50000);
        median.AddNum(3);
        median.FindMedian().Should().Be(2.0000);
    }

    [Fact]
    public void Median_Finder_In_Stream_Negative_Tests()
    {
        var median = new MedianFinder();
        median.AddNum(-1);
        median.FindMedian().Should().Be(-1.00000);
        median.AddNum(-2);
        median.FindMedian().Should().Be(-1.50000);
        median.AddNum(-3);
        median.FindMedian().Should().Be(-2.0000);
        median.AddNum(-4);
        median.FindMedian().Should().Be(-2.5000);
        median.AddNum(-5);
        median.FindMedian().Should().Be(-3.0000);
    }

    [Fact]
    public void Median_Finder_In_Stream_Two_Heaps_Tests()
    {
        var median = new MedianFinderTwoHeaps();
        median.AddNum(1);
        median.AddNum(2);
        median.FindMedian().Should().Be(1.50000);
        median.AddNum(3);
        median.FindMedian().Should().Be(2.0000);
    }

    [Fact]
    public void Median_Finder_In_Stream_Two_Heaps_Negative_Tests()
    {
        var median = new MedianFinderTwoHeaps();
        median.AddNum(-1);
        median.FindMedian().Should().Be(-1.00000);
        median.AddNum(-2);
        median.FindMedian().Should().Be(-1.50000);
        median.AddNum(-3);
        median.FindMedian().Should().Be(-2.0000);
        median.AddNum(-4);
        median.FindMedian().Should().Be(-2.5000);
        median.AddNum(-5);
        median.FindMedian().Should().Be(-3.0000);
    }
}