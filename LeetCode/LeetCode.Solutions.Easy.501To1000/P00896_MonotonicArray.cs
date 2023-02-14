namespace LeetCode.Solutions.Easy.P00896_MonotonicArray;

public class Solution
{
    internal enum Trend
    {
        Unknown,
        Increasing,
        Decreasing
    }

    public bool IsMonotonic(int[] nums)
    {
        if (nums == null || nums.Length == 0) return false;
        Trend trend = Trend.Unknown;
        int last = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            switch (trend)
            {
                case Trend.Unknown:
                    if (nums[i] < last)
                    {
                        trend = Trend.Decreasing;
                    }
                    else if (nums[i] > last)
                    {
                        trend = Trend.Increasing;
                    }
                    break;
                case Trend.Decreasing:
                    if (nums[i] > last)
                    {
                        return false;
                    }
                    break;
                case Trend.Increasing:
                    if (nums[i] < last)
                    {
                        return false;
                    }
                    break;
            }
            last = nums[i];
        }
        return true;
    }
}
