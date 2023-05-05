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
	
	public int Calculate(string s)
	{
		return Resolve(s);
	}

	internal int Negate(string expr)
	{
		return -Resolve(expr);
	}

	internal int Resolve(string expr)
	{
		int val;
		foreach (char c in expr)
		{
			switch(c) 
			{
				case ' ': 
					continue; 

					
			}
		}
	}

	/*
	internal (string l, string r, string op) Parse(string expr)
	{
		foreach (char c in expr) 
		{
			
		}
	}
	*/
}

#region private::Tests

[Theory]
[InlineData("1 + 1", 2)]
[InlineData(" 2-1 + 2 ", 3)]
[InlineData("(1+(4+5+2)-3)+(6+8)", 23)]
[InlineData("(1+(4+5+2)-3)-(6+8)", -2)]
[InlineData("-(1 + 1)", -2)]
[InlineData("(1-(4+5+2)-3)+(6+8)", -1)]
// [InlineData()]
void Test(string expression, int expected) 
{
	int result = new Solution().Calculate(expression);
	Assert.Equal(expected, result);
}

/*

Example 1:
Input: s = "1 + 1"
Output: 2

Example 2:
Input: s = " 2-1 + 2 "
Output: 3

Example 3:
Input: s = "(1+(4+5+2)-3)+(6+8)"
Output: 23

4: 
Input: s = "(1+(4+5+2)-3)-(6+8)"
Output: -2

5: 
Input: s = "-(1 + 1)"
Output: -2

6:
Input: s = "(1-(4+5+2)-3)+(6+8)"
1 - 11 - 3 + 14
Output: -1

*/

#endregion