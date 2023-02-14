using System.Text;

namespace LeetCode.Solutions.Easy.P01071_GcdOfStrings;

public partial class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        StringBuilder gcdBuilder = new StringBuilder(str1[0]);
        string gcd = "";
        int i = 0;
        while (i <= str2.Length / 2) 
        {
            if (CheckGcd(gcdBuilder.ToString(), str2))
            { 
                gcd = gcdBuilder.ToString();
            }
            gcdBuilder.Append(str2[++i]);
        }
        return gcd;
    }

    internal bool CheckGcd(string gcd, string value) 
    {
        if (value.Length % gcd.Length != 0) return false;

        int i = 0;
        while (i < value.Length - 1) 
        {
            if (gcd != value.Substring(i, gcd.Length)) return false;
            i += gcd.Length;
        }
        return true;
    }
}