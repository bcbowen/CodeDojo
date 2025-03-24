<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public string CountAndSay(int n)
{
	string initialValue = "1"; 
	if (n == 1) return initialValue; 
	return Recurse(1, n, initialValue); 
	
}

internal string Recurse(int current, int target, string result) 
{
	StringBuilder sb = new StringBuilder(); 
	int pos = 1; 
	int val = result[0] - '0';
	int count = 1;
	while (pos < result.Length)
	{
		if (result[pos] - '0' == val) 
		{
			count++;
		}
		else
		{
			sb.Append($"{count}{val}");
			count = 1; 
			val = result[pos] - '0'; 
		}
		pos++; 
	}
	sb.Append($"{count}{val}");
	current++;
	if (current == target) 
	{
		return sb.ToString();
	}
	else 
	{
		return Recurse(current, target, sb.ToString()); 
	}
}

#region private::Tests

[Theory]
[InlineData(1, "1")]
[InlineData(2, "11")]
[InlineData(3, "21")]
[InlineData(4, "1211")]
void Test(int n, string expected) 
{
	string result = CountAndSay(n); 
	Assert.Equal(expected, result); 
}

#endregion