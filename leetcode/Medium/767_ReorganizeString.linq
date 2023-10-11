<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public string ReorganizeString(string s)
{
	PriorityQueue<char, int> charQ = new PriorityQueue<char, int>();
	Dictionary<char, int> charCounts = new Dictionary<char, int>();
	foreach(char c in s)
	{
		if (!charCounts.ContainsKey(c)) 
		{
			charCounts.Add(c, 0); 
		}
		charCounts[c]++; 
	}

	foreach (char key in charCounts.Keys) 
	{
		charQ.Enqueue(key, -charCounts[key]); 
	}

	char[] result = new char[s.Length];
	
	// if the most common char is more than half of the letters, it is impossible
	if (charCounts[charQ.Peek()] > Math.Ceiling((double)s.Length / 2)) return ""; 
	
	int index = 0; 

	while (index < s.Length) 
	{
		char primary = charQ.Dequeue();
		if (index > 0 && result[index - 1] == primary) 
		{
			char secondary = charQ.Dequeue(); 
			result[index++] = secondary; 
			charCounts[secondary]--;
			charQ.Enqueue(secondary, -charCounts[secondary]); 
		}
		else 
		{
			result[index++] = primary; 
			charCounts[primary]--;
		}
		charQ.Enqueue(primary, -charCounts[primary]); 
	}
	return new string(result); 
}

public string ReorganizeString2(string s)
{
	char[] chars = s.ToCharArray();

	for (int i = 1; i < chars.Length; i++)
	{
		if (chars[i] == chars[i - 1])
		{
			// look right
			int j = i;
			int k = -1; 
			while (++j < chars.Length && k < 0)
			{
				if (chars[i] != chars[j]) 
				{
					k = j; 
					break;
				}
			}
			// look left
			j = i;
			while (--j >= 0 && k < 0)
			{
				if (chars[i] != chars[j])
				{
					k = j;
					break;
				}
			}

			if (k > -1)
			{
				Swap(chars, i, k);
			}
			else
			{
				return "";
			}
		}
	}
	return new string(chars);
}

public string ReorganizeString1(string s)
{
	char[] chars = s.ToCharArray();
	Array.Sort(chars);

	for (int i = 1; i < chars.Length; i++)
	{
		if (chars[i] == chars[i - 1])
		{
			int j = i + 1;
			while (j < chars.Length && chars[j] == chars[i]) 
			{
				j++;
			}
			if (j < chars.Length) 
			{
				Swap(chars, i, j);
			}
			else 
			{
				return ""; 
			}
		}
	}
	return new string(chars); 
}

private void Swap(char[] chars, int i, int j) 
{
	char temp = chars[i]; 
	chars[i] = chars[j]; 
	chars[j] = temp; 
}

/*
Example 1:

Input: s = "aab"
Output: "aba"
Example 2:

Input: s = "aaab"
Output: ""
*/

[Theory]
[InlineData("aab", true)]
[InlineData("aaab", false)]
[InlineData("vvvlo", true)]
void Test(string value, bool isPossible) 
{
	string result = ReorganizeString(value);
	if (isPossible) 
	{
		Assert.True(IsValid(result));
	}
	else 
	{
		Assert.Equal("", result);
	}
}

[Theory]
[InlineData("aab", false)]
[InlineData("abb", false)]
[InlineData("aaab", false)]
[InlineData("abbc", false)]
[InlineData("abab", true)]
[InlineData("", false)]
void IsValidTest(string value, bool expected)
{
	bool result = IsValid(value);
	Assert.Equal(expected, result); 
}

private bool IsValid(string value) 
{
	if (string.IsNullOrEmpty(value)) return false;
	for(int i = 1; i < value.Length; i++)
	{
		if (value[i] == value[i - 1]) return false;
	}
	return true;
}