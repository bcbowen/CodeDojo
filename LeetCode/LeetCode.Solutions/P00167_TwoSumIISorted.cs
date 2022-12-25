﻿namespace LeetCode.Solutions.P00167_TwoSumIISorted;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int i = 0;
        int j = numbers.Length - 1;
        int[] result = new int[2];
        while (i <= j)
        {
            int sum = numbers[i] + numbers[j];
            if (sum == target)
            {
                result[0] = i + 1;
                result[1] = j + 1;
                break;
            }
            else if (sum < target)
            {
                i++;
            }
            else
            {
                j--;
            }
        }

        return result;

    }
}