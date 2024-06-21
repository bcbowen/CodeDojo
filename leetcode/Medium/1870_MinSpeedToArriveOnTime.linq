<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

public int MinSpeedOnTime(int[] dist, double hour)
{
	int result = -1; 
	
	
	return result; 
}


/*
Input: dist = [1,3,2], hour = 6
Output: 1
Explanation: At speed 1:
- The first train ride takes 1/1 = 1 hour.
- Since we are already at an integer hour, we depart immediately at the 1 hour mark. The second train takes 3/1 = 3 hours.
- Since we are already at an integer hour, we depart immediately at the 4 hour mark. The third train takes 2/1 = 2 hours.
- You will arrive at exactly the 6 hour mark.
Example 2:

Input: dist = [1,3,2], hour = 2.7
Output: 3
Explanation: At speed 3:
- The first train ride takes 1/3 = 0.33333 hours.
- Since we are not at an integer hour, we wait until the 1 hour mark to depart. The second train ride takes 3/3 = 1 hour.
- Since we are already at an integer hour, we depart immediately at the 2 hour mark. The third train takes 2/3 = 0.66667 hours.
- You will arrive at the 2.66667 hour mark.
Example 3:

Input: dist = [1,3,2], hour = 1.9
Output: -1
*/

[Theory]
[InlineData(new[] {1, 3, 2}, 6, 1)]
[InlineData(new[] {1, 3, 2}, 2.7, 3)]
[InlineData(new[] {1, 3, 2}, 1.9, -1)]
void Test(int[] dist, double hour, int expected) 
{
	int result = MinSpeedOnTime(dist, hour); 
	Assert.Equal(expected, result); 
}

