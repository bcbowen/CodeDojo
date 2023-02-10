namespace LeetCode.Solutions.Medium.P00155_MinStack;

public class MinStack
{
    private SortedListNode? _sortedList = null;
    private StackNode? _root = null;
    private Dictionary<StackNode, SortedListNode> _nodeIndex = new Dictionary<StackNode, SortedListNode>();
    public MinStack()
    { }

    public void Push(int val)
    {
        SortedListNode listNode; 
        if (_root == null)
        {
            _root = new StackNode(val);
        }
        else
        {
            _root = _root.Push(val);
        }

        if (_sortedList == null)
        {
            _sortedList = new SortedListNode(val);
            listNode = _sortedList;
        }
        else
        {
            listNode = _sortedList.Insert(val);
        }
        _nodeIndex.Add(_root, listNode);
    }

    public void Pop()
    {
        if (_root != null)
        {
            _root = _root.Pop();
            if (_root != null)
            {
                _nodeIndex.Remove(_root);
            }
        }        
    }

    public int Top()
    {
        return _root != null ? _root.Value : 0;
    }

    public int GetMin()
    {
        return _sortedList != null ? _sortedList.Value : 0;
    }
}

internal class SortedListNode
{
    public SortedListNode(int value)
    {
        Value = value;
    }
    public SortedListNode? Next { get; set; }
    public SortedListNode? Previous { get; set; }

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
    public StackNode(int value)
    {
        Value = value;
    }
    public int Value { get; init; }
    public StackNode? Next { get; set; }

    public StackNode Push(int value)
    {
        StackNode node = new StackNode(value);
        node.Next = this;
        return node;
    }

    public StackNode? Pop() 
    {
        StackNode? node = Next;
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