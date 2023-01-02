using System.Text;

namespace LeetCode.Solutions.P00459_RepeatedSubstringPattern;

public class Solution
{
    public bool RepeatedSubstringPattern(string s)
    {
        StringBuilder substring = new StringBuilder();
        foreach (char c in s)
        {
            substring.Append(c);
            if (Test(s, substring)) return true;
        }
        return false;
    }

    internal bool Test(string main, StringBuilder substring)
    {
        if (main.Length == substring.Length || main.Length % substring.Length != 0) return false;

        int i = 0;
        foreach (char c in main)
        {
            if (c != substring[i]) return false;
            i = (i + 1) % substring.Length;
        }
        return true;
    }
}
