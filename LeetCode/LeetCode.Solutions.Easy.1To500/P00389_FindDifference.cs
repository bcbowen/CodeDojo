namespace LeetCode.Solutions.Easy.P00389_FindDifference;

public class Solution
{
    public char FindTheDifference(string s, string t)
    {
        Dictionary<char, int> letters = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (!letters.ContainsKey(c))
            {
                letters.Add(c, 0);
            }

            letters[c]++;
        }

        foreach (char c in t)
        {
            if (!letters.ContainsKey(c) || letters[c] == 0) return c;
            letters[c]--;
        }

        return ' ';
    }
}