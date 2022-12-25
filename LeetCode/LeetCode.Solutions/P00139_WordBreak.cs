namespace LeetCode.Solutions.P00139_WordBreak;

public class Solution
{
    private bool[] _characters;
    public bool WordBreak(string s, IList<string> wordDict)
    {
        _characters = new bool[s.Length + 1];
        int i = 0;
        Scan(i, s, wordDict);

        for (i = 1; i < s.Length; i++)
        {
            if (_characters[i])
            {
                Scan(i, s, wordDict);
            }
        }

        return _characters[_characters.Length - 1];
    }

    private void Scan(int i, string s, IList<string> wordDict)
    {
        foreach (string word in wordDict)
        {
            if (word[0] == s[i] && i + word.Length < _characters.Length)
            {
                if (s.Substring(i, word.Length) == word)
                {
                    _characters[i + word.Length] = true;
                }

            }
        }

    }
}