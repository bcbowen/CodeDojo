using System.Text;

namespace LeetCode.Solutions.P00709_ToLower;

public class Solution
{
    public string ToLowerCase(string s)
    {
        // 'A': 65
        // 'Z': 90
        // 'a': 97
        StringBuilder lower = new StringBuilder();
        foreach (char c in s)
        {
            int code = (int)c;
            char replacement;
            if (code >= 65 && code <= 90)
            {
                replacement = (char)(code + 32);
            }
            else
            {
                replacement = c;
            }
            lower.Append(replacement);
        }

        return lower.ToString();
    }
}
