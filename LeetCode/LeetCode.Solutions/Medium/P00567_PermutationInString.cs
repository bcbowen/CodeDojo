namespace LeetCode.Solutions.Medium.P00567_PermutationInString;

public partial class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        
        Dictionary<char, int> masterCounts = new Dictionary<char, int>();
        foreach (char c in s1) 
        {
            if (!masterCounts.ContainsKey(c)) 
            {
                masterCounts.Add(c, 0);
            }
            masterCounts[c]++;
        }
        
        for (int i = 0; i <= s2.Length - s1.Length; i++) 
        {
            char c = s2[i];
            if (masterCounts.ContainsKey(c))
            {
                string value = s2.Substring(i, s1.Length);
                if (IsPermutation(value, masterCounts)) return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Value is a permutation of the characters stored in masterCounts
    /// </summary>
    /// <param name="value"></param>
    /// <param name="masterCounts"></param>
    /// <returns></returns>
    internal bool IsPermutation(string value, Dictionary<char, int> masterCounts) 
    {
        Dictionary<char, int> charCounts = CopyCounts(masterCounts);
        foreach (char c in value) 
        {
            if (charCounts.ContainsKey(c) && charCounts[c] > 0)
            {
                charCounts[c]--;
            }
            else 
            {
                return false;
            }
        }

        return true;
    }

    private Dictionary<char, int> CopyCounts(Dictionary<char, int> masterCounts) 
    {
        Dictionary<char, int> charCounts = new();
        foreach (char key in masterCounts.Keys) 
        {
            charCounts[key] = masterCounts[key];
        }

        return charCounts; 
    }
}