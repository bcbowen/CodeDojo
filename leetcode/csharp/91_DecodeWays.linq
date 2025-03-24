<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int NumDecodings(string s)
{
	if (s[0] == '0') return 0;
	int total = 0; 
	//int[] total = new int[s.Length + 1];
	for (int i = 0; i < s.Length; i++) 
	{
		if (s[i] > '0' && s[i] <= '9') total++;
		if (i < s.Length - 1)
		{
			if (s[i] == '1') 
			{
				total++;
			}
			else if (s[i] == '2' && s[i + 1] < '7') 
			{
				total++; 			
			}
		}
		
		
	}
	
	return total; 
}


/*
Example 1:

Input: s = "12"
Output: 2
Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).
Example 2:

Input: s = "226"
Output: 3
Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
Example 3:

Input: s = "06"
Output: 0
Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is different from "06").
*/
[Theory]
[InlineData("12", 2)]
[InlineData("226", 3)]
[InlineData("06", 0)]
void Test(string s, int expected) 
{
	int result = NumDecodings(s);
	Assert.Equal(expected, result);
}