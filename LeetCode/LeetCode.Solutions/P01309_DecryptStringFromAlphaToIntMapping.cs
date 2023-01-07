using System.Text;

namespace LeetCode.Solutions.P01309_DecryptStringFromAlphaToIntMapping;

public class Solution
{
    public string FreqAlphabets(string s)
    {
        // 'a': 1; 'i': 9
        // 'j': 10#; 'z': 26#
        // 'a' ASCII: 97


        Dictionary<string, char> lookup = LoadDictionary();

        Stack<char> letters = new Stack<char>();
        int i = s.Length - 1;

        while (i >= 0)
        {
            if (s[i] == '#')
            {
                letters.Push(lookup[s.Substring(i - 2, 3)]);
                i -= 3;
            }
            else
            {
                letters.Push(lookup[s[i].ToString()]);
                i--;
            }
        }

        StringBuilder result = new StringBuilder();
        while (letters.Count > 0)
        {
            result.Append(letters.Pop());
        }
        return result.ToString();
    }

    internal Dictionary<string, char> LoadDictionary()
    {
        Dictionary<string, char> lookup = new Dictionary<string, char>();

        int val = 1;
        for (int i = 97; i < 106; i++)
        {
            lookup.Add(val.ToString(), (char)i);
            val++;
        }

        for (int i = 106; i <= 122; i++)
        {
            lookup.Add($"{val}#", (char)i);
            val++;
        }

        return lookup;
    }
}
