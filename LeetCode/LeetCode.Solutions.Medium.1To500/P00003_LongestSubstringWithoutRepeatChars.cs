namespace LeetCode.Solutions.Medium.P00003_LongestSubstringWithoutRepeatChars;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;
        if (s.Length == 1) return 1;

        int i = 0;
        int j = 0; 
        Dictionary<char, int> counts = new Dictionary<char, int>();
        counts.Add(s[i], 1);
        string result = s[i].ToString();
        while (j < s.Length - 1) 
        {
            j++;
            if (!counts.ContainsKey(s[j]))
            {
                counts.Add(s[j], 1);
            }
            else 
            {
                counts[s[j]]++;
                while (counts.ContainsKey(s[j]) && counts[s[j]] > 1)
                {
                    counts[s[i]]--;
                    i++;
                }
            }
            
            if ((j - i + 1) > result.Length) 
            {
                result = s.Substring(i, j - i + 1);
            }
        }
        
        return result.Length;
    }
}