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
	public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
	{
		bool[] result = new bool[candies.Length];
		int max = candies.Max();
		for (int i = 0; i < candies.Length; i++)
		{
			result[i] = candies[i] + extraCandies >= max;
		}

		return result;
	}
}

/*
Example 1:

Input: candies = [2,3,5,1,3], extraCandies = 3
Output: [true,true,true,false,true] 
Explanation: If you give all extraCandies to:
- Kid 1, they will have 2 + 3 = 5 candies, which is the greatest among the kids.
- Kid 2, they will have 3 + 3 = 6 candies, which is the greatest among the kids.
- Kid 3, they will have 5 + 3 = 8 candies, which is the greatest among the kids.
- Kid 4, they will have 1 + 3 = 4 candies, which is not the greatest among the kids.
- Kid 5, they will have 3 + 3 = 6 candies, which is the greatest among the kids.
Example 2:

Input: candies = [4,2,1,1,2], extraCandies = 1
Output: [true,false,false,false,false] 
Explanation: There is only 1 extra candy.
Kid 1 will always have the greatest number of candies, even if a different kid is given the extra candy.
Example 3:

Input: candies = [12,1,12], extraCandies = 10
Output: [true,false,true]
*/

[Theory]
[InlineData(new[] { 2, 3, 5, 1, 3 }, 3, new[] { true, true, true, false, true })]
[InlineData(new[] { 4, 2, 1, 1, 2 }, 1, new[] { true, false, false, false, false })]
[InlineData(new[] { 12, 1, 12 }, 10, new[] { true, false, true })]
void Test(int[] candies, int extra, bool[] expected)
{
	IList<bool> result = new Solution().KidsWithCandies(candies, extra);
	Assert.Equal(expected, result);
}
