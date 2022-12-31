namespace LeetCode.Solutions.P00346_MovingAverageDataStream;

public class MovingAverage
{
    private int _size;
    private int[] _values;
    private int _head = -1;
    private int _tail = -1;
    private int _windowTotal;
    private int _count;

    public MovingAverage(int size)
    {
        _size = size;
        _values = new int[size];
        _windowTotal = 0;
        _count = 0;
    }

    private int GetNextIndex(int index)
    {
        return (index + 1) % _size;
    }

    public double Next(int val)
    {

        if (_count < _size)
        {
            if (_count == 0)
            {
                _head = 0;
            }
            _count++;
            _windowTotal += val;
            _tail++;
        }
        else
        {
            _windowTotal -= _values[_head];
            _windowTotal += val;
            _head = GetNextIndex(_head);
            _tail = GetNextIndex(_tail);

        }

        _values[_tail] = val;
        return (double)_windowTotal / _count;
    }
}
