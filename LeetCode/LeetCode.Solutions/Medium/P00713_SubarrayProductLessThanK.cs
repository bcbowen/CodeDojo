namespace LeetCode.Solutions.P00713_SubarrayProductLessThanK;

public class Solution
{
    public int NumSubarrayProductLessThanK_1(int[] nums, int k)
    {
        if (k == 0) return 0;

        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < k) count++;
        }

        int windowSize = 2;
        long currentWindowValue = 0;
        while (windowSize <= nums.Length)
        {
            currentWindowValue = 1;
            for (int i = 0; i < windowSize; i++)
            {
                currentWindowValue *= nums[i];
                if (currentWindowValue > k)
                {
                    currentWindowValue = -1;
                    break;
                }
            }
            if (currentWindowValue > 0 && currentWindowValue < k)
            {
                //Console.WriteLine($"ws: {windowSize}; c: {count}; cwv: {currentWindowValue}");
                count++;
            }


            for (int i = 1; i < nums.Length - windowSize + 1; i++)
            {
                if (currentWindowValue > 1)
                {
                    currentWindowValue /= nums[i - 1];
                    currentWindowValue *= nums[i + windowSize - 1];
                }
                else
                {
                    currentWindowValue = nums[i];
                    for (int j = i + 1; j < i + windowSize; j++)
                    {
                        currentWindowValue *= nums[j];
                        if (currentWindowValue < 1 || currentWindowValue >= k)
                        {
                            currentWindowValue = -1;
                            break;
                        }
                    }
                }
                if (currentWindowValue > 0 && currentWindowValue < k)
                {
                    //Console.WriteLine($"ws: {windowSize}; c: {count}; cwv: {currentWindowValue}; i: {i}");
                    count++;
                }

            }
            windowSize++;
        }

        return count;
    }

    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1) return 0;

        int product = 1;
        int result = 0;
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            product *= nums[right];
            while (product >= k) product /= nums[left++];
            result += right - left + 1;
        }

        return result;
    }
}
