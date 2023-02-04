using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Medium.P00028_ImplementStrStr;

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        if (needle == "") return 0;

        for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            if (haystack[i] == needle[0])
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i;
                }
            }
        }

        return -1;
    }

}