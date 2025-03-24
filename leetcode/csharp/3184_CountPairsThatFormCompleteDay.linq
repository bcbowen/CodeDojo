<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

public int CountCompleteDayPairs(int[] hours)
{
	int result = 0;
	for (int i = 0; i < hours.Length - 1; i++)
	{
		for(int j = i + 1; j < hours.Length; j++)
		{
			if ((hours[i] + hours[j]) % 24 == 0) 
			{
				result++; 
			}
		}
	}
	return result;
}

/*
Input: hours = [12,12,30,24,24]
Output: 2

Input: hours = [72,48,24,3]
Output: 3
*/

[Theory]
[InlineData(new[] {12,12,30,24,24}, 2)]
[InlineData(new[] {72,48,24,3}, 3)]
void Test(int[] hours, int expected) 
{
	int result = CountCompleteDayPairs(hours); 
	Assert.Equal(expected, result); 
}
