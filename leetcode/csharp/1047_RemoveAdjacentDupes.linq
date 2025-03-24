<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public string RemoveDuplicates(string s)
{
	// Note: Remove dupes 2 at a time, not ALL dupes at once
	// ex: abccbd -> ad BUT abcccbd -> abcbd
	Stack<char> letters = new Stack<char>();
	StringBuilder sb = new StringBuilder();
	foreach (char c in s)
	{
		if (letters.Count > 0 && letters.Peek() == c) 
		{
			letters.Pop();
		}
		else 
		{
			letters.Push(c);
		}
	}
	while(letters.Count() > 0) 
	{
		sb.Insert(0, letters.Pop());
	}
	return sb.ToString();
}

public string RemoveDuplicatesFirst(string s)
{
	StringBuilder sb = new StringBuilder(s);
	int i = 0;
	int j = 0;
	while (i < sb.Length)
	{
		j = i + 1;
		if (j >= sb.Length) break;
		while (j < sb.Length && sb[i] == sb[j])
		{
			while (j < sb.Length && sb[j] == sb[i]) j++;
			sb.Remove(i, j - i);
			if (i > 0) i--;
			j = i + 1;
		}
		i++;
	}
	return sb.ToString();
}

#region private::Tests

[Fact]
void DupesAtBeginningTest()
{
	string value = "aaaaab"; 
	string expected = "ab"; 
	string result = RemoveDuplicates(value);
	Assert.Equal(expected, result);
}

[Fact]
void DupesAtEndTest()
{
	string value = "baaaaa"; 
	string expected = "ba"; 
	string result = RemoveDuplicates(value);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("aaaaaaaaa", "a")]
[InlineData("abbaca", "ca")]
[InlineData("abcd", "abcd")]
[InlineData("abcccbd", "abcbd")]
[InlineData("aaaaabcccbd", "abcbd")]
[InlineData("abcccbdddddd", "abcb")]
void Test(string value, string expected)
{
	string result = RemoveDuplicates(value);
	Assert.Equal(expected, result);
}

#endregion