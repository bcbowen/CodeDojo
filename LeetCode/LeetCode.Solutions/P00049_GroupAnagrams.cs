using System.Numerics;
using System.Text.RegularExpressions;
using System.Text;

namespace LeetCode.Solutions.P00049_GroupAnagrams;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        List<IList<string>> result = new List<IList<string>>();
        Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
        foreach (string s in strs)
        {
            string key = GetKey(s);
            if (!anagrams.ContainsKey(key))
            {
                anagrams.Add(key, new List<string>());
            }
            anagrams[key].Add(s);
        }

        foreach (string key in anagrams.Keys)
        {
            result.Add(anagrams[key]);
        }

        return result;
    }

    internal string GetKey(string value)
    {
        char[] chars = value.ToCharArray();
        Array.Sort(chars);
        string key = new string(chars);
        return key;
    }
}