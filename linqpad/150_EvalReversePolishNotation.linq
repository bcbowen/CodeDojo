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
	public int EvalRPN(string[] tokens)
	{
		Stack<int> values = new Stack<int>();
		int value1;
		int value2;
		foreach (string token in tokens)
		{
			switch (token)
			{
				case "+":
					value1 = values.Pop();
					value2 = values.Pop();
					values.Push(value1 + value2);
					break;
				case "-":
					value1 = values.Pop();
					value2 = values.Pop();
					values.Push(value2 - value1);
					break;
				case "*":
					value1 = values.Pop();
					value2 = values.Pop();
					values.Push(value1 * value2);
					break;
				case "/":
					value1 = values.Pop();
					value2 = values.Pop();
					values.Push(value2 / value1);
					break;
				default:
					if (int.TryParse(token, out value1))
					{
						values.Push(value1);
					}
					break;
			}

		}

		return values.Pop();
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { "2", "1", "+", "3", "*" }, 9)]
[InlineData(new[] { "4", "13", "5", "/", "+" }, 6)]
[InlineData(new[] { "4", "3", "-" }, 1)]
[InlineData(new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22)]
void Test(string[] tokens, int expected)
{
	int result = new Solution().EvalRPN(tokens);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: tokens = ["2","1","+","3","*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9

Example 2:
Input: tokens = ["4","13","5","/","+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6

Example 3:
Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
Output: 22
Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
= ((10 * (6 / (12 * -11))) + 17) + 5
= ((10 * (6 / -132)) + 17) + 5
= ((10 * 0) + 17) + 5
= (0 + 17) + 5
= 17 + 5
= 22
*/

#endregion