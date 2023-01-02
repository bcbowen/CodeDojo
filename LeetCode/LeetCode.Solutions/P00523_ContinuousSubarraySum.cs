namespace LeetCode.Solutions.P00523_ContinuousSubarraySum;

public class Solution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        if (nums.Length < 2) return false;
        Dictionary<int, int> hashmap = new Dictionary<int, int>();
        hashmap.Add(0, 0);
        int i = 0;
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
            sum %= k;
            if (hashmap.ContainsKey(sum))
            {
                int val = hashmap[sum];
                if (val < i)
                {
                    return true;
                }
            }
            else
            {
                hashmap.Add(sum, i + 1);
            }
            i++;
        }


        return false;
    }

    public bool CheckSubarraySum_slow(int[] nums, int k)
    {
        for (int windowSize = 2; windowSize <= nums.Length; windowSize++)
        {
            int windowValue = 0;
            for (int i = 0; i < windowSize; i++)
            {
                windowValue += nums[i];
            }

            if (windowValue == 0 || windowValue % k == 0) return true;

            for (int i = windowSize; i < nums.Length; i++)
            {
                windowValue -= nums[i - windowSize];
                windowValue += nums[i];
                if (windowValue == 0 || windowValue % k == 0) return true;
            }
        }
        return false;
    }
}
