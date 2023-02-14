namespace LeetCode.Solutions.Hard.P00295_FindMedianFromDataStream;

public class MedianFinder
{
    PriorityQueue<int, int> firstHalf = new PriorityQueue<int, int>();
    PriorityQueue<int, int> secondHalf = new PriorityQueue<int, int>();
    private int _round;

    public MedianFinder()
    {
        _round = 0;
    }

    public void AddNum(int num)
    {
        if (firstHalf.Count == 0 && secondHalf.Count == 0)
        {
            firstHalf.Enqueue(num, -num);
        }
        else if (firstHalf.Count > 0 && firstHalf.Peek() > num)
        {
            firstHalf.Enqueue(num, -num);
        }
        else
        {
            secondHalf.Enqueue(num, num);
        }

        _round++;

        // rebalance the queues... equal for even rounds, off by one for odd rounds
        int transfer;
        if (_round % 2 == 0)
        {
            while (firstHalf.Count > secondHalf.Count)
            {
                transfer = firstHalf.Dequeue();
                secondHalf.Enqueue(transfer, transfer);
            }
            while (secondHalf.Count > firstHalf.Count)
            {
                transfer = secondHalf.Dequeue();
                firstHalf.Enqueue(transfer, -transfer);
            }
        }
        else
        {
            while (firstHalf.Count - secondHalf.Count > 1)
            {
                transfer = firstHalf.Dequeue();
                secondHalf.Enqueue(transfer, transfer);
            }

            while (secondHalf.Count - firstHalf.Count > 1)
            {
                transfer = secondHalf.Dequeue();
                firstHalf.Enqueue(transfer, -transfer);
            }
        }
    }

    public double FindMedian()
    {
        if (_round % 2 == 0)
        {
            return ((double)firstHalf.Peek() + secondHalf.Peek()) / 2;
        }
        else
        {
            return firstHalf.Count > secondHalf.Count ? firstHalf.Peek() : secondHalf.Peek();
        }
    }
}