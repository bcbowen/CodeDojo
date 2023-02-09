namespace LeetCode.Solutions.Easy.P01046_LastStoneWeight;

public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        foreach (int stone in stones)
        {
            queue.Enqueue(stone, -stone);
        }
        while (queue.Count > 1)
        {
            int x = queue.Dequeue();
            int y = queue.Dequeue();
            if (x > y)
            {
                queue.Enqueue(x - y, y - x);
            }
        }

        return queue.Count > 0 ? queue.Peek() : 0;
    }
}