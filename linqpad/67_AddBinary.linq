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
	public string AddBinary(string a, string b)
	{
		StringBuilder result = new StringBuilder();
		int aIndex = a.Length - 1;
		int bIndex = b.Length - 1;
		bool carry = false;
		while (aIndex > -1 || bIndex > -1)
		{
			int aVal = aIndex > -1 ? int.Parse(a[aIndex].ToString()) : 0;
			int bVal = bIndex > -1 ? int.Parse(b[bIndex].ToString()) : 0;
			int cVal = aVal + bVal;
			if (carry) 
			{ 
				switch (cVal)
				{
					case 0:
						carry = false;
						cVal = 1;
						break;
					case 1: 
						cVal = 0;
						carry = true;
						break;
					case 2: 
						cVal = 1; 
						carry = true;
						break;
				}
			} 
			else
			{
				if (cVal == 2) 
				{
					cVal = 0; 
					carry = true;
				}
			}
			aIndex--;
			bIndex--;
			result.Insert(0, cVal);
		}
		if (carry) 
		{
			result.Insert(0, 1);
		}
		return result.ToString();
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);
/*
Example 1:
Input: a = "11", b = "1"
Output: "100"

Example 2:
Input: a = "1010", b = "1011"
Output: "10101"
*/
[Theory]
[InlineData("11", "1", "100")]
[InlineData("1010", "1011", "10101")]
void Test(string a, string b, string expected) 
{
	string result = new Solution().AddBinary(a, b);
	Assert.Equal(expected, result);
	
}

#endregion