namespace LeetCode.Solutions.Medium.P00622_CircularQueue;

public class MyCircularQueue
{
    private int _front = -1;
    private int _rear = -1;
    private int[] _queue;


    public MyCircularQueue(int k)
    {
        _queue = new int[k];
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
        {
            return false;
        }
        if (IsEmpty())
        {
            _queue[0] = value;
            _front = 0;
            _rear = 0;
        }
        else
        {
            int next = Wrap(_rear + 1);
            _queue[next] = value;
            _rear = next;
        }

        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty()) return false;

        if (_front == _rear)
        {
            _front = -1;
            _rear = -1;
        }
        else
        {
            int next = Wrap(_front + 1);
            _front = next;
        }

        return true;
    }

    public int Front()
    {
        return IsEmpty() ? -1 : _queue[_front];
    }

    public int Rear()
    {
        return IsEmpty() ? -1 : _queue[_rear];
    }

    public bool IsEmpty()
    {
        return _front == -1;
    }

    public bool IsFull()
    {
        int next = Wrap(_rear + 1);
        return next == _front;
    }

    internal int Wrap(int index)
    {
        return index % _queue.Length;
    }
}
