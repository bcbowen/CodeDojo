namespace LeetCode.Solutions.P00242_ValidAnagram;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        char[] cs = s.ToCharArray();
        char[] ct = t.ToCharArray();
        Array.Sort(cs);
        Array.Sort(ct);
        return cs.SequenceEqual(ct);
    }
}