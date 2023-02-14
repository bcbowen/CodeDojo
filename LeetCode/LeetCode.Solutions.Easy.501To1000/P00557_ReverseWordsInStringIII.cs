using System.Text;

namespace LeetCode.Solutions.Easy.P00557_ReverseWordsInStringIII;

public class Solution
{
    public string ReverseWords(string s)
    {

        StringBuilder sb = new StringBuilder();
        string[] words = s.Split(' ');
        foreach (string word in words)
        {
            int i = word.Length - 1;
            while (i >= 0)
            {
                sb.Append(word[i--]);
            }
            sb.Append(' ');
        }
        sb.Length--;
        return sb.ToString();
    }
}