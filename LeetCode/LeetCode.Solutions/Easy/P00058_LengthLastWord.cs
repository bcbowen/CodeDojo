namespace LeetCode.Solutions.Easy.P00058_LengthLastWord;

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int count = 0;
        int i = s.Length - 1;
        while (s[i] == ' ')
        {
            i--;
        }
        while (i >= 0 && s[i] != ' ')
        {
            i--;
            count++;
        }

        return count;
    }
}