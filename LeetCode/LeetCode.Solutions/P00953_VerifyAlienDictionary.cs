namespace LeetCode.Solutions.P00953_VerifyAlienDictionary;

public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        Dictionary<char, int> dictionary = InitDictionary(order);
        int comparison;
        for (int i = 1; i < words.Length; i++)
        {
            comparison = Compare(words[i - 1], words[i], dictionary);
            if (comparison > 0) return false;
        }

        return true;
    }

    internal Dictionary<char, int> InitDictionary(string order)
    {
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        int index = 0;

        foreach (char c in order)
        {
            dictionary.Add(c, index++);
        }

        return dictionary;
    }

    internal int Compare(string word1, string word2, Dictionary<char, int> dictionary)
    {
        int i = 0;
        while (i < Math.Min(word1.Length, word2.Length))
        {
            if (word1[i] != word2[i])
            {
                return dictionary[word1[i]] - dictionary[word2[i]];
            }
            i++;
        }
        return word1.Length - word2.Length;
    }
}
