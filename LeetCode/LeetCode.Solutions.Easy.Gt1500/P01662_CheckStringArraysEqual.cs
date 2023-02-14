using System.Text;

namespace LeetCode.Solutions.Easy.P01662_CheckStringArraysEqual;

public class Solution
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        StringBuilder sb1 = new StringBuilder();
        foreach (string s in word1)
        {
            sb1.Append(s);
        }

        StringBuilder sb2 = new StringBuilder();
        foreach (string s in word2)
        {
            sb2.Append(s);
        }

        return sb1.Equals(sb2);
    }
}