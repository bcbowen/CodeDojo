namespace LeetCode.Solutions.Easy.P00217_ContainsDupes;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();
        foreach (int i in nums)
        {
            if (seen.Contains(i)) return true;
            seen.Add(i);
        }

        return false;
    }
}