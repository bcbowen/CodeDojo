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
	public bool ValidateStackSequences(int[] pushed, int[] popped)
	{
		/*
		Stack<int> test = new Stack<int>();
		int j = 0;
		for (int i = 0; i < pushed.Length; i++)
		{
			if (i == popped[j]) 
			{
				test.Pop();
			}
			else 
			{
				test.Push();
			}
		}
		*/
		int i = 0;
		int j = 0;
		while (pushed[i] != popped[j]) 
		{
			i++; 
		}
		
	}
}

/*

Example 1:
Input: pushed = [1,2,3,4,5], popped = [4,5,3,2,1]
Output: true
Explanation: We might do the following sequence:
push(1), push(2), push(3), push(4),
pop() -> 4,
push(5),
pop() -> 5, pop() -> 3, pop() -> 2, pop() -> 1

Example 2:
Input: pushed = [1,2,3,4,5], popped = [4,3,5,1,2]
Output: false
Explanation: 1 cannot be popped before 2.

*/

[Fact]
[InlineData(new[] {1,2,3,4,5}, new[] {4,5,3,2,1}, true)]
[InlineData(new[] {1,2,3,4,5}, new[] {4,3,5,1,2}, false)]
void Test(int[] pushed, int[] popped, bool expected) 
{
	bool result = new Solution().ValidateStackSequences(pushed, popped); 
	Assert.Equal(expected, result);
}
