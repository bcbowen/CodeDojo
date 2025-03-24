<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

public int[] RelativeSortArray(int[] arr1, int[] arr2)
{
	Array.Sort(arr1);
	Dictionary<int, int> positions = new Dictionary<int, int>();
	Dictionary<int, int> counts = new Dictionary<int, int>();
	List<int> result = new List<int>();
	for (int i = 0; i < arr2.Length; i++)
	{
		positions.Add(i, arr2[i]);
	}
	var groups = arr1
	.GroupBy(n => n)
	.Select(g => (Number: g.Key, Count: g.Count()))
	.ToList();

	foreach ((int Number, int Count) in groups)
	{
		counts.Add(Number, Count);
	}

	for (int i = 0; i < arr2.Length; i++)
	{
		int val = positions[i];
		int count = counts[val];
		for (int j = 0; j < count; j++)
		{
			result.Add(val);
		}
	}

	foreach (int val in arr1.Except(arr2).OrderBy(v => v))
	{
		int count = counts[val];
		for (int j = 0; j < count; j++)
		{
			result.Add(val);
		}
	}

	return result.ToArray();
}

/*
Example 1:
Input: arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
Output: [2,2,2,1,4,3,3,9,6,7,19]

Example 2:
Input: arr1 = [28,6,22,8,44,17], arr2 = [22,28,8,6]
Output: [22,28,8,6,17,44]
*/

[Theory]
[InlineData(new[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new[] { 2, 1, 4, 3, 9, 6 }, new[] { 2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19 })]
[InlineData(new[] { 28, 6, 22, 8, 44, 17 }, new[] { 22, 28, 8, 6 }, new[] { 22, 28, 8, 6, 17, 44 })]
void Test(int[] arr1, int[] arr2, int[] expected)
{
	int[] result = RelativeSortArray(arr1, arr2);
	Assert.Equal(expected, result);
}
