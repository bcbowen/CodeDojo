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
	/*
	if (ratings.Length == 1) return 1;
	int total = 0; 
	total += ratings[0] > ratings[1] ? 2 : 1; 
	for (int i = 1; i < ratings.Length - 1; i++)
	{
		total += ratings[i] > ratings[i - 1] || ratings[i] > ratings[i + 1] ? 2 : 1; 
	}
	int last = ratings.Length - 1; 
	total += ratings[last] > ratings[last - 1] ? 2 : 1; 
	*/
	int total = 0;
	for(int i = 0; i < ratings.Length; i++)
	{
		total += GetValue(ratings, i);
	}
	return total;
}

internal int GetValue(int[] ratings, int index) 
{
	//{ 1, 2, 87, 87, 87, 2, 1}, 13)] // 1 + 2 + 2 + 1 + 2 + 2 + 1 = 11

	if (index == 0) 
	{
		return ratings[0] > ratings[1] ? 2 : 1;
	}
	else if (index == ratings.Length - 1) 
	{
		return ratings[ratings.Length - 1] > ratings[ratings.Length - 2] ? 2 : 1;
	}
	else 
	{
		return ratings[index] > ratings[index - 1] || ratings[index] > ratings[index + 1] ? 2 : 1;
	}
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
*/

[Theory]
[InlineData(new[] {1, 0, 2}, 5)]
[InlineData(new[] { 1, 2, 2 }, 4)]
[InlineData(new[] { 1, 2, 87, 87, 87, 2, 1}, 13)] // 1 + 2 + 2 + 1 + 2 + 2 + 1 = 11
void Test(int[] ratings, int expected) 
{
	int result = Candy(ratings); 
	Assert.Equal(expected, result); 
}

[Fact]
void GetValueTest() 
{
	int[] ratings = new int[] { 1, 2, 87, 87, 87, 2, 1 };
	int[] expected = new int[] { 1, 2, 3, 1, 3, 2, 1 };
	for (int i = 0; i < ratings.Length; i++) 
	{
		int result = GetValue(ratings, i); 
		Assert.Equal(expected[i], result);
	}
}

#endregion