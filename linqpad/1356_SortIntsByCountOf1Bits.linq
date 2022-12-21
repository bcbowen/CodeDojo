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
	public int[] SortByBits(int[] arr)
	{
		SortedList<int, List<int>> numbersByBitCount = new SortedList<int, List<int>>();
		
		foreach (int i in arr) 
		{
			int bitCount = GetBitCount(i);
			if (!numbersByBitCount.ContainsKey(bitCount)) 
			{
				numbersByBitCount.Add(bitCount, new List<int>());
			}
			
			numbersByBitCount[bitCount].Add(i);
			
		}
		List<int> result = new List<int>();

		
		foreach(int key in numbersByBitCount.Keys)
		{
			numbersByBitCount[key].Sort();
			result.AddRange(numbersByBitCount[key]);
		}
		
		return result.ToArray();
	}

	internal int GetBitCount(int value)
	{
		int result = 0;
		while(value > 0) 
		{
			if ((value & 1) == 1) result++; 
			value >>= 1;
		}
		return result;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

/*
Example 1:
Input: arr = [0,1,2,3,4,5,6,7,8]
Output: [0,1,2,4,8,3,5,6,7]
Explantion: [0] is the only integer with 0 bits.
[1,2,4,8] all have 1 bit.
[3,5,6] have 2 bits.
[7] has 3 bits.
The sorted array by bits is [0,1,2,4,8,3,5,6,7]

Example 2:
Input: arr = [1024,512,256,128,64,32,16,8,4,2,1]
Output: [1,2,4,8,16,32,64,128,256,512,1024]
Explantion: All integers have 1 bit in the binary representation, you should just sort them in ascending order.
*/

[Theory]
[InlineData(new[] {0,1,2,3,4,5,6,7,8}, new[] {0,1,2,4,8,3,5,6,7})]
[InlineData(new[] {1024,512,256,128,64,32,16,8,4,2,1}, new[] {1,2,4,8,16,32,64,128,256,512,1024})]
void SortByBitsTests(int[] arr, int[] expected) 
{
	int[] result = new Solution().SortByBits(arr); 
	Assert.Equal(expected, result);
}

#endregion