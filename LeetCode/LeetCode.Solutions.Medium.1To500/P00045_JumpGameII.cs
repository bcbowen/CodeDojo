namespace LeetCode.Solutions.Medium.P00045_JumpGameII;

public partial class Solution
{
    public int Jump(int[] nums) 
    {
        int i = 0;
        int j = 0;
        while (j < nums.Length) 
        {
            // find step 
            for (int k = i; k <= j; k++) 
            { }
        }
        return 1;
    }

    /*
    {
        int index = 0;
        int step = nums[index];
        int stepCount = 1; 

        while (index < nums.Length - 1) 
        {
            int nextIndex = 0;
            int maxReach = 0;
            int[] subArray = nums.Skip(index + 1).Take(Math.Min(step, nums.Length - 1)).ToArray();
            for (int i = 0; i < subArray.Length; i++) 
            {
                if (subArray[i] + i >= maxReach) 
                {
                    nextIndex = index + i;
                    maxReach = subArray[i] + i;
                }
            }
            index = nextIndex;
            step = nums[index];
            stepCount++;
        }
        return stepCount;
    }
    */
}