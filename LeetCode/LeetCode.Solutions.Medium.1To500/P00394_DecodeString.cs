using System.Text;

namespace LeetCode.Solutions.Medium.P00394_DecodeString;

public class Solution
{
    public string DecodeString(string s)
    {

        StringBuilder result = new StringBuilder();
        Stack<char> chars = new Stack<char>();
        int i = 0;
        while (i < s.Length) 
        {
            switch (s[i]) 
            {
                case ']':
                    char c;
                    while (chars.Count > 0 && (c = chars.Pop()) != '[')
                    { 
                        result.Insert(0, c);
                    }
                    int reps = int.Parse(chars.Pop().ToString());
                    for (int j = 0; j < reps; j++) 
                    {
                        for (int k = 0; k < result.Length; k++) 
                        {
                            chars.Push(result[k]);
                        }
                    }
                    result.Clear();
                    break;
                default:
                    chars.Push(s[i]);
                    break;
            }
            i++; 
        }

        foreach (char c in chars) 
        {
            result.Insert(0, c); 
        }

        return result.ToString(); 
       
    }
}



/*
Example 1:

Input: s = "3[a]2[bc]"
Output: "aaabcbc"
Example 2:

Input: s = "3[a2[c]]"
Output: "accaccacc"
Example 3:

Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"
*/