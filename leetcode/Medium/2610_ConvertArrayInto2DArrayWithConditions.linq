<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public IList<IList<int>> FindMatrix(int[] nums)
{
	List<IList<int>> list = new List<IList<int>>();
	Dictionary<int, int> counts = new Dictionary<int, int>();
	list.Add(new List<int>());
	for (int i = 1; i <= nums.Length; i++) 
	{
		counts.Add(i, 0); 
	}
	foreach (int num in nums)
	{
		if (counts[num] > list.Count - 1) 
		{
			list.Add(new List<int>()); 
		}
		list[counts[num]].Add(num); 
		counts[num]++; 

	}

	return list;
}

public IList<IList<int>> FindMatrix1(int[] nums)
{
	List<IList<int>> list = new List<IList<int>>();

	list.Add(new List<int>());
	foreach (int num in nums)
	{
		int i = 0;
		if (list[i].Contains(num))
		{
			do
			{
				if (i == list.Count - 1)
				{
					list.Add(new List<int>());
				}
				i++;
			} while (list[i].Contains(num));
			list[i].Add(num);
		}
		else
		{
			list[i].Add(num);
		}
	}

	return list;
}

/*
Example 1:
Input: nums = [1,3,4,1,2,3,1]
Output: [[1,3,4,2],[1,3],[1]]
Explanation: We can create a 2D array that contains the following rows:
- 1,3,4,2
- 1,3
- 1
All elements of nums were used, and each row of the 2D array contains distinct integers, so it is a valid answer.
It can be shown that we cannot have less than 3 rows in a valid array.

Example 2:
Input: nums = [1,2,3,4]
Output: [[4,3,2,1]]
Explanation: All elements of the array are distinct, so we can keep all of them in the first row of the 2D array.
*/

[Theory]
[InlineData(new[] { 1, 3, 4, 1, 2, 3, 1 }, new[] { 1, 3, 4, 2 }, new[] { 1, 3 }, new[] { 1 })]
[InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 })]
void Test(int[] nums, params int[][] expected)
{
	IList<IList<int>> result = FindMatrix(nums);
	Assert.Equal(result.Count, expected.Length);
	for (int i = 0; i < result.Count; i++)
	{
		int[] row = result[i].ToArray();
		Assert.Equal(row, expected[i]);
	}
}