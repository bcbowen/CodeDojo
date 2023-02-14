namespace LeetCode.Solutions.Easy.P00125_ValidPalindrome;

public class Solution
{
    public bool IsPalindrome(string s)
    {
        s = s.ToUpper();
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            while (i < s.Length && !char.IsLetterOrDigit(s[i])) i++;
            while (j > 0 && !char.IsLetterOrDigit(s[j])) j--;
            if (i > j) break;
            if (s[i++] != s[j--]) return false;
        }
        return true;
    }
}