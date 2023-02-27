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
	//const string Opens = "([{";
	
	
	public bool IsValid(string s)
	{
		if(string.IsNullOrEmpty(s)) return true;
		
		Dictionary<char, char> closerLookup = new Dictionary<char, char>();
		closerLookup.Add('(', ')');
		closerLookup.Add('[', ']');
		closerLookup.Add('{', '}');
		
		Stack<char> closers = new Stack<char>();
		foreach (char c in s)
		{
			if (closerLookup.ContainsKey(c))
			{
				closers.Push(closerLookup[c]);
			}
			else
			{
				if( closers.Count() == 0 || c != closers.Pop() )
				{
					return false;
				}
			}
		}
		
		return closers.Count() == 0;
	}

}


#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData("()", true)]
[InlineData("()[]{}", true)]
[InlineData("(]", false)]
void Test(string input, bool expected) 
{ 
	bool result = new Solution().IsValid(input); 
	Assert.Equal(expected, result);	
}

/*
Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "()[]{}"
Output: true

Example 3:
Input: s = "(]"
Output: false
*/
#endregion