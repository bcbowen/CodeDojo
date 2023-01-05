namespace LeetCode.Solutions.P01790_OneStringSwapMakesStringsEqual;

public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        if (s1 == null || s2 == null || s1.Length != s2.Length) return false;
        List<int> diffs = new List<int>();
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                if (diffs.Count > 1) return false;
                diffs.Add(i);
            }
        }
        switch (diffs.Count)
        {
            case 0:
                return true;
            case 2:
                return s1[diffs[0]] == s2[diffs[1]] && s1[diffs[1]] == s2[diffs[0]];
            default:
                return false;
        }

    }
}
