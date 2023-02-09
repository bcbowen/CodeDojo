namespace LeetCode.Solutions.Medium.P00215_KthLargestElementInArray;

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> q = new PriorityQueue<int, int>();
        foreach (int num in nums)
        {
            q.Enqueue(num, -num);
        };

        int result = 0;
        for (int i = 0; i < k; i++)
        {
            result = q.Dequeue();
        }

        return result;
    }
}