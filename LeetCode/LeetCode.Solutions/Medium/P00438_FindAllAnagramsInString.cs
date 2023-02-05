namespace LeetCode.Solutions.P00438_FindAllAnagramsInString;

public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        List<int> indices = new List<int>();
        if (p.Length > s.Length) return indices;

        Dictionary<char, int> chars = new Dictionary<char, int>();
        Dictionary<char, int> charsCheck = new Dictionary<char, int>();
        foreach (char c in p)
        {
            if (!chars.ContainsKey(c))
            {
                chars.Add(c, 0);
            }
            if (!charsCheck.ContainsKey(c))
            {
                charsCheck.Add(c, 0);
            }
            chars[c]++;
        }

        int j = p.Length - 1;
        for (int k = 0; k <= j; k++)
        {
            if (charsCheck.ContainsKey(s[k]))
            {
                charsCheck[s[k]]++;
            }
        }

        if (CompareLists(chars, charsCheck))
        {
            indices.Add(0);
        }

        for (int i = 1; i <= s.Length - p.Length; i++)
        {
            if (charsCheck.ContainsKey(s[i - 1]))
            {
                charsCheck[s[i - 1]]--;
            }

            j++;
            if (charsCheck.ContainsKey(s[j]))
            {
                charsCheck[s[j]]++;
            }

            if (CompareLists(chars, charsCheck))
            {
                indices.Add(i);
            }

        }

        return indices;
    }

    private bool CompareLists(Dictionary<char, int> chars, Dictionary<char, int> charsCheck)
    {
        foreach (char key in chars.Keys)
        {
            if (chars[key] != charsCheck[key])
            {
                return false;
            }
        }
        return true;
    }
}

