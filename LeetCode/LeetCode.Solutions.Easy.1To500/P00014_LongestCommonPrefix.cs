namespace LeetCode.Solutions.Easy.P00014_LongestCommonPrefix;

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        string prefix = strs[0];
        if (!string.IsNullOrEmpty(prefix))
        {
            for (int i = 1; i < strs.Length; i++)
            {
                if (string.IsNullOrEmpty(strs[i]) || prefix[0] != strs[i][0])
                {
                    prefix = string.Empty;
                    break;
                }
                if (prefix.Length > strs[i].Length)
                {
                    prefix = prefix.Substring(0, strs[i].Length);
                }

                for (int j = 0; j < prefix.Length; j++)
                {
                    if (prefix[j] != strs[i][j])
                    {
                        prefix = prefix.Substring(0, j);
                    }
                }

            }
        }


        return prefix;
    }

}