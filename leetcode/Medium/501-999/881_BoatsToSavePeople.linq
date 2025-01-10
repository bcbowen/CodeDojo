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
	public int NumRescueBoats(int[] people, int limit)
	{
		Array.Sort(people);
		int i = 0;
		int j = people.Length - 1;
		int boats = 0;

		while (i <= j)
		{
			int load = 0;
			int count = 0;
			while (load + people[j] <= limit && count < 2)
			{
				load += people[j];
				count++;
				if (--j < 0) break;
			}

			while (load + people[i] <= limit && count < 2)
			{
				load += people[i];
				count++;
				if (++i == people.Length) break;
			}
			boats++;
		}

		return boats;
	}
}

/*

Example 1:
Input: people = [1,2], limit = 3
Output: 1
Explanation: 1 boat (1, 2)

Example 2:
Input: people = [3,2,2,1], limit = 3
Output: 3
Explanation: 3 boats (1, 2), (2) and (3)

Example 3:
Input: people = [3,5,3,4], limit = 5
Output: 4
Explanation: 4 boats (3), (3), (4), (5)

*/

[Theory]
/**/
[InlineData(new[] { 1, 2 }, 3, 1)]
[InlineData(new[] { 3, 2, 2, 1 }, 3, 3)]
[InlineData(new[] { 3, 5, 3, 4 }, 5, 4)]
[InlineData(new[] { 3, 2, 3, 2, 2 }, 6, 3)]
void Test(int[] people, int limit, int expected)
{
	int result = new Solution().NumRescueBoats(people, limit);
	Assert.Equal(expected, result);
}

