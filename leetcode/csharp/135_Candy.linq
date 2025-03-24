<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


public int Candy(int[] ratings)
{
	int[] values = new int[ratings.Length];
	Array.Fill(values, 1); 
	
	for (int i = 0; i < ratings.Length - 1; i++)
	{
		if (ratings[i + 1] > ratings[i]) 
		{
			values[i + 1] = values[i] + 1;
		}
	}

	for (int i = ratings.Length - 1; i > 0; i--)
	{
		if (ratings[i - 1] > ratings[i])
		{
			values[i - 1] = Math.Max(values[i - 1], values[i] + 1);
		}
	}

	return values.Sum();
}

#region Tests

/*
Example 1:
Input: ratings = [1,0,2]
Output: 5
Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.

Example 2:
Input: ratings = [1,2,2]
Output: 4
Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
The third child gets 1 candy because it satisfies the above two conditions.

[InlineData(new[] { 1, 2, 87, 87, 87, 2, 1}, 13)] // 1 + 2 + 3 + 1 + 2 + 2 + 1 = 11

1 2 3 1 1 1 1
1 2 3 1 3 2 1 


*/

[Theory]
[InlineData(new[] {1, 0, 2}, 5)]
[InlineData(new[] { 1, 2, 2 }, 4)]
[InlineData(new[] { 1, 2, 87, 87, 87, 2, 1 }, 13)] // 1 + 2 + 3 + 1 + 3 + 2 + 1 = 13
[InlineData(new[] { 1, 3, 4, 5, 2}, 11)] // 1 + 2 + 3 + 4 + 1
void Test(int[] ratings, int expected) 
{
	int result = Candy(ratings); 
	Assert.Equal(expected, result); 
}

#endregion