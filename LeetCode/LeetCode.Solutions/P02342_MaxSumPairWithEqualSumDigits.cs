namespace LeetCode.Solutions.P02342_MaxSumPairWithEqualSumDigits;

public class Solution
{
    public int MaximumSum(int[] nums)
    {
        Dictionary<int, int[]> pairs = new Dictionary<int, int[]>();

        foreach (int num in nums)
        {
            int sumDigits = SumDigits(num);
            if (pairs.ContainsKey(sumDigits))
            {
                int temp;
                if (num > pairs[sumDigits][1])
                {
                    temp = pairs[sumDigits][1];
                    pairs[sumDigits][1] = num;
                    if (temp > pairs[sumDigits][0])
                    {
                        pairs[sumDigits][0] = temp;
                    }
                }
                else if (num > pairs[sumDigits][0])
                {
                    pairs[sumDigits][0] = num;
                }
            }
            else
            {
                pairs.Add(sumDigits, new[] { num, 0 });
            }

        }

        int maxSum = -1;
        foreach (int key in pairs.Keys)
        {
            if (pairs[key][1] > 0)
            {
                int sum = pairs[key][0] + pairs[key][1];
                if (sum > maxSum) maxSum = sum;
            }
        }

        return maxSum;
    }

    private int SumDigits(int val)
    {
        int sum = 0;
        while (val > 0)
        {
            sum += val % 10;
            val /= 10;
        }

        return sum;
    }

}