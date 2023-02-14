namespace LeetCode.Solutions.Easy.P00232_ImplementQueueUsingStacks;

public class MyQueue
{

    private Stack<int> _stackA;
    private Stack<int> _stackB;

    public MyQueue()
    {
        _stackA = new Stack<int>();
        _stackB = new Stack<int>();
    }

    private void ResetQueues()
    {
        while (_stackB.Count > 0)
        {
            _stackA.Push(_stackB.Pop());
        }
    }

    private void QueueNext()
    {
        while (_stackA.Count > 1)
        {
            _stackB.Push(_stackA.Pop());
        }
    }

    public void Push(int x)
    {
        ResetQueues();
        _stackA.Push(x);
    }

    public int Pop()
    {
        if (_stackA.Count == 1) return _stackA.Pop();

        ResetQueues();
        QueueNext();
        return _stackA.Pop();
    }

    public int Peek()
    {
        if (_stackA.Count == 1) return _stackA.Peek();

        ResetQueues();
        QueueNext();
        return _stackA.Peek();
    }

    public bool Empty()
    {
        return _stackA.Count + _stackB.Count == 0;
    }
}
