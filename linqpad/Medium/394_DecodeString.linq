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
					int reps = 0;
					int place = 1;
					while (chars.Count > 0 && char.IsDigit(chars.Peek()))
					{
						int digit = chars.Pop() - '0';
						reps += digit * place;
						place *= 10;
					}

					//int reps = int.Parse(chars.Pop().ToString());
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
			if (!char.IsDigit(c)) result.Insert(0, c);
		}

		return result.ToString();

	}
}



#region private::Tests
[Theory]
[InlineData("3", "")]
[InlineData("10[ben]", "benbenbenbenbenbenbenbenbenben")]
[InlineData("3[a]2[bc]", "aaabcbc")]
[InlineData("3[a2[c]]", "accaccacc")]
[InlineData("3[a2[b2[c]]]", "abccbccabccbccabccbcc")]
[InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
[InlineData("abcabccdcdcdef", "abcabccdcdcdef")]
/**/
public void DecodeStringTests(string s, string expected)
{
	string result = new Solution().DecodeString(s);
	Assert.Equal(expected, result);
}

#endregion