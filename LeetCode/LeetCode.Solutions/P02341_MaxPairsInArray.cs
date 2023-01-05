namespace LeetCode.Solutions.P02341_MaxPairsInArray;

public class Solution
{
    public int[] NumberOfPairs(int[] nums)
    {
        int[] result = new int[2];

        Dictionary<int, int> valueCounts = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (valueCounts.ContainsKey(num))
            {
                valueCounts[num]++;
            }
            else
            {
                valueCounts.Add(num, 1);
            }
        }

        int singles = 0;
        int pairs = 0;
        foreach (int key in valueCounts.Keys)
        {
            singles += valueCounts[key] % 2;
            pairs += valueCounts[key] / 2;
        }
        result[0] = pairs;
        result[1] = singles;
        return result;
    }
}