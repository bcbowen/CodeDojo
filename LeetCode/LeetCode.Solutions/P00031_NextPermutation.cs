namespace LeetCode.Solutions.P00031_NextPermutation;

public class Solution
{
    public void NextPermutation(int[] nums)
    {
        for (int i = nums.Length - 1; i > 0; i--)
        {
            if (nums[i] > nums[i - 1])
            {
                int index = i;
                int value = nums[i];
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] < value && nums[j] > nums[i - 1])
                    {
                        index = j;
                        value = nums[j];
                    }
                }

                SwapDigits(nums, i - 1, index);
                Array.Sort(nums, i, nums.Length - i);
                return;
            }

        }
        Array.Sort(nums);
    }


    internal void SwapDigits(int[] a, int i, int j)
    {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }
}