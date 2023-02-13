namespace LeetCode.Solutions.Easy.P01523_CountOddNumbersInInterval;

public partial class Solution
{
    public int CountOdds(int low, int high)
    {
        if ((low & 1) == 0) 
        {
            low++;
        }
        
        if (low > high) return 0;

        return (high - low) / 2 + 1; 
    }
}