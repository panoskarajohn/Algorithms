namespace Problems.DataStructures;

/// <summary>
///     Taken from leetcode
/// </summary>
public class SingleLinkedList
{
    private readonly Node _head;
    private int _size;

    public SingleLinkedList()
    {
        _size = 0;
        _head = new Node(0);
    }

    public int Get(int index)
    {
        if (index < 0 || index >= _size)
            return -1;

        var current = _head;
        for (var i = 0; i < index + 1; i++) current = current.Next;

        return current.Value;
    }

    public void AddAtHead(int val)
    {
        AddAtIndex(0, val);
    }

    public void AddAtTail(int val)
    {
        AddAtIndex(_size, val);
    }

    public void AddAtIndex(int index, int val)
    {
        if (index > _size) return;
        if (index < 0) return;

        _size++;

        var prev = _head;
        for (var i = 0; i < index; i++) prev = prev.Next;

        var toAdd = new Node(val);
        toAdd.Next = prev.Next;
        prev.Next = toAdd;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= _size) return;
        _size--;
        var prev = _head;
        for (var i = 0; i < index; i++)
            prev = prev.Next;

        prev.Next = prev.Next.Next;
    }
}

public class Node
{
    public Node Next;
    public int Value;

    public Node(int value)
    {
        Value = value;
    }
}