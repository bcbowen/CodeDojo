namespace LeetCode.Solutions.Easy.P01588_SumOfOddLengthArrays;

public class Solution
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        int sum = 0;

        // sum elements in array 
        sum += arr.Sum(i => i);

        if (arr.Length < 3) return sum;

        int subLength = 3;
        while (subLength <= arr.Length)
        {
            int i = 0;
            int j = 0;
            while (i + subLength <= arr.Length)
            {
                for (j = i; j < i + subLength; j++)
                {
                    sum += arr[j];
                }
                i++;
            }
            subLength += 2;
        }
        return sum;
    }
}
