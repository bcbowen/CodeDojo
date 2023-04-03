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
	public string Interpret(string command)
	{
		StringBuilder result = new StringBuilder();
		for (int i = 0; i < command.Length; i++)
		{
			switch (command[i])
			{
				case 'G':
					result.Append(command[i]);
					break;
				case ')':
					result.Append(command[i - 1] == '(' ? "o" : "al"); 
					break;
			}
		}
		return result.ToString();
	}
}

/*
Example 1:

Input: command = "G()(al)"
Output: "Goal"
Explanation: The Goal Parser interprets the command as follows:
G -> G
() -> o
(al) -> al
The final concatenated result is "Goal".
Example 2:

Input: command = "G()()()()(al)"
Output: "Gooooal"
Example 3:

Input: command = "(al)G(al)()()G"
Output: "alGalooG"
*/

[Theory]
[InlineData("G()(al)", "Goal")]
[InlineData("G()()()()(al)", "Gooooal")]
[InlineData("(al)G(al)()()G", "alGalooG")]
void Test(string command, string expected) 
{
	string result = new Solution().Interpret(command);
	Assert.Equal(expected, result);
}
