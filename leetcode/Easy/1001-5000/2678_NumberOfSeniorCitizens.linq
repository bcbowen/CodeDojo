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
	public int CountSeniors(string[] details)
	{
		int count = 0;

		foreach (string detail in details)
		{
			switch (detail[11]) 
			{
				case '6': 
					if (detail[12] != '0') count++;
					break; 
				case '7': 
				case '8': 
				case '9': 
					count++; 
					break; 
			
			}
		}
		
		return count; 
	}
}

/*
Example 1:

Input: details = ["7868190130M7522","5303914400F9211","9273338290F4010"]
Output: 2
Explanation: The passengers at indices 0, 1, and 2 have ages 75, 92, and 40. Thus, there are 2 people who are over 60 years old.
Example 2:

Input: details = ["1313579440F2036","2921522980M5644"]
Output: 0
Explanation: None of the passengers are older than 60.

*/

[Theory]
[InlineData(new[] { "7868190130M7522", "5303914400F9211", "9273338290F4010" }, 2)]
[InlineData(new[] { "1313579440F2036", "2921522980M5644" }, 0)]
void Test(string[] details, int expected)
{
	int result = new Solution().CountSeniors(details);
	Assert.Equal(expected, result);
}