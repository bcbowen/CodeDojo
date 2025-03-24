<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
{
	int baseSatisfied = 0;
	for (int i = 0; i < customers.Length; i++)
	{
		if (grumpy[i] != 1) baseSatisfied += customers[i];
	}

	int maxSatisfied = baseSatisfied;

	int left = 0, right = 0;
	int currentSatisfied = baseSatisfied;

	// build window of size minutes
	if (grumpy[left] == 1) currentSatisfied += customers[left];
	while (right - left < minutes - 1 && right < customers.Length - 1)
	{
		right++;
		if (grumpy[right] == 1) currentSatisfied += customers[right];
	}
	maxSatisfied = Math.Max(currentSatisfied, maxSatisfied);

	// slide window to the right
	while (right < customers.Length - 1)
	{
		if (grumpy[left] == 1) currentSatisfied -= customers[left];
		left++;

		right++;
		if (grumpy[right] == 1) currentSatisfied += customers[right];
		maxSatisfied = Math.Max(currentSatisfied, maxSatisfied);
	}

	return maxSatisfied;
}

/*
Example 1:
Input: customers = [1,0,1,2,1,1,7,5], grumpy = [0,1,0,1,0,1,0,1], minutes = 3
Output: 16
Explanation: The bookstore owner keeps themselves not grumpy for the last 3 minutes. 
The maximum number of customers that can be satisfied = 1 + 1 + 1 + 1 + 7 + 5 = 16.

Example 2:
Input: customers = [1], grumpy = [0], minutes = 1
Output: 1
*/

[Theory]
[InlineData(new[] { 2, 6, 6, 9 }, new[] { 0, 0, 1, 1 }, 1, 17)]
[InlineData(new[] { 1, 0, 1, 2, 1, 1, 7, 5 }, new[] { 0, 1, 0, 1, 0, 1, 0, 1 }, 3, 16)]
[InlineData(new[] { 1 }, new[] { 0 }, 1, 1)]
void Test(int[] customers, int[] grumpy, int minutes, int expected)
{
	int result = MaxSatisfied(customers, grumpy, minutes);
	Assert.Equal(expected, result);
}

