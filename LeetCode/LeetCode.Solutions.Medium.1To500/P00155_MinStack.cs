namespace LeetCode.Solutions.Medium.P00155_MinStack;

public class MinStack
{
    private SortedListNode? _sortedList = null;
    private StackNode? _root = null;
    public MinStack()
    { }

    public void Push(int val)
    {
        if (_root == null)
        {
            _root = new StackNode(val);
        }
        else
        {
            _root = _root.Push(val);
        }
    }

    public void Pop()
    {
        _root = root.Pop();
    }

    public int Top()
    {
        return _root.Value;
    }

    public int GetMin()
    {
        return _sortedList.Value;
    }
}

internal class SortedListNode
{
    public SortedListNode(int value)
    {
        Value = value;
    }
    public SortedListNode Next { get; set; }
    public SortedListNode Previous { get; set; }

    public int Value { get; init; }

    public SortedListNode Insert(int value)
    {
        if (value < Value)
        {
            SortedListNode listNode = new SortedListNode(value);
            listNode.Next = this;
            this.Previous = listNode;
            return listNode;
        }

        if (Next == null)
        {
            SortedListNode listNode = new SortedListNode(value);
            Next = listNode;
            listNode.Previous = this;
            return listNode;
        }

        return Next.Insert(value);
    }

    public void Remove()
    {
        if (Next != null)
        {
            if (Previous != null)
            {
                Next.Previous = Previous;
                Previous.Next = Next;
                Next = null;
                Previous = null;
            }
            else
            {
                Next.Previous = null;
                Next = null;
            }
        }
        else if (Previous != null)
        {
            Previous.Next = null;
            Previous = null;
        }
    }
}

internal class StackNode
{
    private SortedListNode _referencedListNode;
    public StackNode(int value, SortedListNode sortedList)
    {
        Value = value;
        if (sortedList == null)
        {
            _referencedListNode = new SortedListNode(value);
        }
        else
        {
            _referencedListNode = sortedList.Insert(value);
        }
    }
    public int Value { get; init; }
    public StackNode Next { get; set; }

    public StackNode Push(int value)
    {
        StackNode node = new StackNode(value);
        node.Next = this;
        return node;
    }

    public StackNode Pop() 
    {
        _referencedListNode.Remove();
        StackNode node = Next;
        Next = null;
        return node;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */