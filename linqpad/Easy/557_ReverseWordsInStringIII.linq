<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public string ReverseWords(string s)
	{
		
		StringBuilder sb = new StringBuilder();
		string[] words = s.Split(' ');
		foreach(string word in words) 
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

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);
/*
Example 1:

Input: s = "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
Example 2:

Input: s = "God Ding"
Output: "doG gniD"
*/
[Theory]
[InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
[InlineData("God Ding", "doG gniD")]
void ReverseWordsTest(string s, string expected) 
{
	string result = new Solution().ReverseWords(s);
	Assert.Equal(expected, result);
}

#endregion