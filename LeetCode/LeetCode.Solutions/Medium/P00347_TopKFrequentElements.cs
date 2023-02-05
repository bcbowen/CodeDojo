namespace LeetCode.Solutions.P00347_TopKFrequentElements;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (!counts.ContainsKey(num))
            {
                counts.Add(num, 0);
            }
            counts[num]++;
        }

        PriorityQueue<int, int> q = new PriorityQueue<int, int>();
        foreach (int key in counts.Keys)
        {
            q.Enqueue(key, -counts[key]);
        }

        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = q.Dequeue();
        }
        return result;
    }
}
