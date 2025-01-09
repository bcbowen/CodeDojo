<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

	/*
	Example 1:

Input: n = 00000000000000000000000000001011
Output: 3
Explanation: The input binary string 00000000000000000000000000001011 has a total of three '1' bits.
Example 2:

Input: n = 00000000000000000000000010000000
Output: 1
Explanation: The input binary string 00000000000000000000000010000000 has a total of one '1' bit.
Example 3:

Input: n = 11111111111111111111111111111101
Output: 31
Explanation: The input binary string 11111111111111111111111111111101 has a total of thirty one '1' bits.
	*/
}

public class Solution
{
	public int HammingWeight(uint n)
	{
		int bitCount = 0;
		uint mask = 1;

		for(int i = 0; i < 32; i++)
		{
			if ((n & mask) == mask) bitCount++;
			mask <<= 1;
		}

		return bitCount;
	}

	public int HammingWeightFirst(uint n)
	{
		int bitCount = 0;
		long mask = (long)Math.Pow(2, 32);
		
		while (mask > 0) 
		{
			if ((n & mask) == mask) bitCount++;
			mask /= 2;
		}
		
		return bitCount;
	}
}

#region private::Tests

[Theory]
[InlineData("00000000000000000000000000001011", 3)]
[InlineData("00000000000000000000000010000000", 1)]
[InlineData("11111111111111111111111111111101", 31)]
[InlineData("00000000000000000000000000000001", 1)]
[InlineData("00000000000000000000000000000010", 1)]
public void HammingWeightTest(string s, int expected)
{
	uint n = Convert.ToUInt32(s, 2);
	int result = new Solution().HammingWeight(n);
	Assert.Equal(expected, result);
}

#endregion