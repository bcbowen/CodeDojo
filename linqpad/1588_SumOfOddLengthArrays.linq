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
	public int SumOddLengthSubarrays(int[] arr)
	{
		int sum = 0;

		// sum elements in array 
		sum += arr.Sum(i => i);
		
		if (arr.Length < 3) return sum;
		
		int subLength = 3;
		while (subLength <= arr.Length) 
		{
			int i = 0;
			int j = 0;
			while (i + subLength <= arr.Length)
			{
				for (j = i; j < i + subLength; j++) 
				{
					sum += arr[j];
				}
				i++;
			}
			subLength += 2;
		}
		return sum;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(new[] { 1, 4, 2, 5, 3 }, 58)]
[InlineData(new[] { 1, 2 }, 3)]
[InlineData(new[] { 10, 11, 12 }, 66)]
void Test(int[] arr, int expected)
{
	int result = new Solution().SumOddLengthSubarrays(arr);
	Assert.Equal(expected, result);
}

#endregion