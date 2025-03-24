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
	public string PredictPartyVictory(string senate)
	{
		int[] counts = new int[2];
		char[] senators = new char[senate.Length];
		int i;
		for (i = 0; i < senate.Length; i++)
		{
			char c = senate[i]; 
			senators[i] = c;
			switch(c)
			{
				case 'R': 
					counts[0]++; 
					break; 
				case 'D': 
					counts[1]++; 
					break;
			}
		}

		i = 0;
		while (counts[0] > 0 && counts[1] > 0)
		{
			switch(senators[i]) 
			{
				case 'R': 
					BlockOne('D', i, senators); 
					counts[1]--;
					break;
				case 'D':
					BlockOne('R', i, senators);
					counts[0]--;
					break;
			}
			i = i == senators.Length - 1 ? 0 : i + 1;
		}
		
		if (counts[0] == 0) return "Dire";
		return "Radiant"; 
	}

	internal void BlockOne(char party, int index, char[] senators)
	{
		for (int i = index + 1; i < senators.Length; i++)
		{
			if (senators[i] == party) 
			{
				senators[i] = 'X'; 
				return;
			}
		}

		for (int i = 0; i < index; i++)
		{
			if (senators[i] == party)
			{
				senators[i] = 'X';
				return;
			}

		}
	}
}


/*
Example 1:
Input: senate = "RD"
Output: "Radiant"
Explanation: 
The first senator comes from Radiant and he can just ban the next senator's right in round 1. 
And the second senator can't exercise any rights anymore since his right has been banned. 
And in round 2, the first senator can just announce the victory since he is the only guy in the senate who can vote.

Example 2:
Input: senate = "RDD"
Output: "Dire"
Explanation: 
The first senator comes from Radiant and he can just ban the next senator's right in round 1. 
And the second senator can't exercise any rights anymore since his right has been banned. 
And the third senator comes from Dire and he can ban the first senator's right in round 1. 
And in round 2, the third senator can just announce the victory since he is the only guy in the senate who can vote.
*/

[Theory]
[InlineData("RD", "Radiant")]
[InlineData("RDD", "Dire")]
void Test(string senate, string expected) 
{
	string result = new Solution().PredictPartyVictory(senate);
	Assert.Equal(expected, result);
}

