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
	public int[] DailyTemperatures(int[] temperatures)
	{
		Stack<(int, int)> tempStack = new Stack<(int, int)>();
		int[] answers = new int[temperatures.Length];

		tempStack.Push((0, temperatures[0]));
		for(int i = 1; i < temperatures.Length; i++) 
		{
			int index = 0; 
			int temp = 0; 
			if (tempStack.Count > 0) (index, temp) = tempStack.Peek();
					
			while(temperatures[i] > temp) 
			{
				(index, temp) = tempStack.Pop();
				answers[index] = i - index; 
				if (tempStack.Count == 0) break;
				(index, temp) = tempStack.Peek();
			}			
			tempStack.Push((i, temperatures[i]));
		}
		return answers;
	}
}

#region private::Tests

[Theory]
[InlineData(new[] {73,74,75,71,69,72,76,73 }, new[] {1,1,4,2,1,1,0,0 })]
[InlineData(new[] {30,40,50,60 }, new[] {1,1,1,0 })]
[InlineData(new[] { 30,60,90}, new[] {1,1,0 })]
// [InlineData(new[] { }, new[] {})]
void Tests(int[] temps, int[] expected) 
{
	int[] result = new Solution().DailyTemperatures(temps);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: temperatures = [73,74,75,71,69,72,76,73]
Output: [1,1,4,2,1,1,0,0]

Example 2:
Input: temperatures = [30,40,50,60]
Output: [1,1,1,0]

Example 3:
Input: temperatures = [30,60,90]
Output: [1,1,0]
*/

#endregion