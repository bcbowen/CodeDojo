namespace LeetCode.Solutions.Easy.P00703_KthLargestElementInStream;

public class KthLargest
{
    PriorityQueue<int, int> _q;
    int _k;

    public KthLargest(int k, int[] nums)
    {
        _q = new PriorityQueue<int, int>();
        _k = k;
        foreach (int num in nums)
        {
            _q.Enqueue(num, num);
        }

        while (_q.Count > _k)
        {
            _q.Dequeue();
        }
    }

    public int Add(int val)
    {
        _q.Enqueue(val, val);
        while (_q.Count > _k)
        {
            _q.Dequeue();
        }
        return _q.Peek();
    }
}
