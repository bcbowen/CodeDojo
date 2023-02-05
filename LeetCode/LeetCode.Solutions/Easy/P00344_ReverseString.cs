namespace LeetCode.Solutions.Easy;

public class Solution
{
    public void ReverseString(char[] s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            char c = s[i];
            s[i] = s[j];
            s[j] = c;
            i++;
            j--;
        }

    }
}