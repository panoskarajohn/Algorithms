namespace Problems.Heap;

/// <summary>
///     Easy solution and with the worst complexity
/// </summary>
public class MedianFinder
{
    private readonly List<int> _store;

    public MedianFinder()
    {
        _store = new List<int>();
    }

    public void AddNum(int num)
    {
        _store.Add(num);
    }

    public double FindMedian()
    {
        var n = _store.Count;
        _store.Sort();
        return n % 2 == 1 ? _store[n / 2] : (_store[n / 2 - 1] + _store[n / 2]) * 0.5;
    }
}

public class MedianFinderTwoHeaps
{
    private readonly PriorityQueue<int, int> _maxHeap;
    private readonly PriorityQueue<int, int> _minHeap;

    public MedianFinderTwoHeaps()
    {
        _minHeap = new PriorityQueue<int, int>();
        _maxHeap = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        _maxHeap.Enqueue(num, -num);
        var max = _maxHeap.Dequeue();
        _minHeap.Enqueue(max, max);
        if (_minHeap.Count > _maxHeap.Count)
        {
            var min = _minHeap.Dequeue();
            _maxHeap.Enqueue(min, -min);
        }
    }

    public double FindMedian()
    {
        if (_minHeap.Count == _maxHeap.Count)
            return (_maxHeap.Peek() + _minHeap.Peek()) * 0.5;
        return _maxHeap.Peek();
    }
}