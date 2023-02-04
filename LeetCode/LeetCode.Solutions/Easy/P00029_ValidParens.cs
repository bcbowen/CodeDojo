using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Easy.P00029_ValidParens;

public class Solution
{
    public bool IsValid(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;

        Dictionary<char, char> closerLookup = new Dictionary<char, char>();
        closerLookup.Add('(', ')');
        closerLookup.Add('[', ']');
        closerLookup.Add('{', '}');

        Stack<char> closers = new Stack<char>();
        foreach (char c in s)
        {
            if (closerLookup.ContainsKey(c))
            {
                closers.Push(closerLookup[c]);
            }
            else
            {
                if (closers.Count() == 0 || c != closers.Pop())
                {
                    return false;
                }
            }
        }

        return closers.Count() == 0;
    }


}