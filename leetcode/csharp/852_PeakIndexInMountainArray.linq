<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int PeakIndexInMountainArray(int[] arr)
{
	int l = 0;
	int r = arr.Length - 1;
	while (l < r) 
	{
		int mid = (l + r) / 2;
		if (arr[mid] < arr[mid + 1])
		{
			l = mid + 1; 
		}
		else 
		{
			r = mid;
		}
	}

	return l;
}
/*
private int FindPeak(int[] arr, int l, int r, int mid)
{
	if (arr[mid - 1] < arr[mid] && arr[mid + 1] < arr[mid])
	{
		return mid;
	}
	else if (arr[mid - 1] > arr[mid])
	{
		r = mid;
	}
	else
	{
		l = mid;
	}
	mid = l + ((r - l) / 2);
	if (mid == l) return Math.Min(arr[mid], arr[r]);
	if (mid == r) return Math.Max(arr[mid], arr[l]);
	return FindPeak(arr, l, r, mid);
}
*/
#region private::Tests

/*
Example 1:
Input: arr = [0,1,0]
Output: 1

Example 2:
Input: arr = [0,2,1,0]
Output: 1

Example 3:
Input: arr = [0,10,5,2]
Output: 1
 
*/

[Theory]
[InlineData(new[] { 0, 1, 0 }, 1)]
[InlineData(new[] { 0, 2, 1, 0 }, 1)]
[InlineData(new[] { 0, 10, 5, 2 }, 1)]
[InlineData(new[] { 0, 1, 5, 6, 10, 2 }, 4)]
[InlineData(new[] { 0, 10, 5, 2, 1 }, 1)]
[InlineData(new[] { 3, 4, 5, 1 }, 2)]
void Test(int[] arr, int expected)
{
	int result = PeakIndexInMountainArray(arr);
	Assert.Equal(expected, result);
}

#endregion