namespace LeetCode.Solutions.P01167_MinCostToConnectSticks;

public class Solution
{
    public int ConnectSticks(int[] sticks)
    {
        if (sticks.Length < 2) return 0;

        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        foreach (int stick in sticks)
        {
            queue.Enqueue(stick, stick);
        }

        int cost = 0;
        while (queue.Count > 1)
        {
            int x = queue.Dequeue();
            int y = queue.Dequeue();
            queue.Enqueue(x + y, x + y);
            cost += x + y;
        }

        return cost;
    }
}
