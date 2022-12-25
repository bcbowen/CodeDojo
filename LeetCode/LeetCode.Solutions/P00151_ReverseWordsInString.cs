using System.Text;

namespace LeetCode.Solutions.P00151_ReverseWordsInString;

public class Solution
{
    public string ReverseWords(string s)
    {
        StringBuilder result = new StringBuilder();
        string[] words = s.Split(' ');
        for (int i = words.Length - 1; i >= 0; i--)
        {
            if (!string.IsNullOrEmpty(words[i])) result.Append(words[i] + ' ');
        }
        return result.ToString().Trim();
    }
}