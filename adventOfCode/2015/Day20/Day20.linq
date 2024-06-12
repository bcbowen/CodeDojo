<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	const int input = 29000000;
	// part 1 takes 4:11
	// Part1(input);
	Part2(input);
}

// You can define other methods, fields, classes and namespaces here

internal int[] GetFactors(int a)
{
	List<int> factors = new List<int>() { 1, a };
	for (int i = 2; i <= a / 2; i++)
	{
		if ((a % i) == 0 && !factors.Contains(i))
		{
			factors.Add(i);
			factors.Add(a / i);
		}
	}

	return factors.Distinct().ToArray();
}

internal int GetPresentCount(int houseNumber) 
{
	int[] factors = GetFactors(houseNumber);
	int count = 0;
	foreach (int factor in factors) 
	{
		count += factor * 10; 
	}
	return count; 
}

internal void Part1(int targetCount)
{
	int houseNumber = 1;
	int presentCount = 10;
	while (presentCount < targetCount) 
	{
		houseNumber++; 
		presentCount = GetPresentCount(houseNumber);
	}
	Console.WriteLine($"House Number part 1: {houseNumber}"); 
}

internal void Part2(int targetCount) 
{
	List<int> presentCounts = new List<int>(); 
	int houseNumber = 0;
	int presentCount = 11;
	int lookAhead = houseNumber;
	while (presentCount < targetCount) 
	{
		houseNumber++;
		lookAhead = houseNumber;
		for (int i = 0; i < 50; i++)
		{
			while(presentCounts.Count() < lookAhead + 1)
			{
				presentCounts.Add(0);
			}
			presentCounts[lookAhead] += houseNumber * 11;
			lookAhead += houseNumber; 
		}
		presentCount = presentCounts[houseNumber];
	}
	// too high: 3,255,840
	// 705,600
	int max = 0;
	int first = 0; 
	for(int i = 0; i < presentCounts.Count; i++)
	{
		if (presentCounts[i] >= targetCount && first == 0) 
		{
			first = i;
		}
		max = Math.Max(max, presentCounts[i]);
	}
	Console.WriteLine($"max: {max}; first: {first}: {presentCounts[first]}"); 
	Console.WriteLine($"Part2 answer: {first} present count: {presentCounts[first]}");
}

/*
House 1 got 10 presents.
House 2 got 30 presents.
House 3 got 40 presents.
House 4 got 70 presents.
House 5 got 60 presents.
House 6 got 120 presents.
House 7 got 80 presents.
House 8 got 150 presents.
House 9 got 130 presents.
*/

[Theory]
[InlineData(1, 10)]
[InlineData(2, 30)]
[InlineData(3, 40)]
[InlineData(4, 70)]
[InlineData(5, 60)]
[InlineData(6, 120)]
[InlineData(7, 80)]
[InlineData(8, 150)]
[InlineData(9, 130)]
void Test(int houseNumber, int expected) 
{
	int result = GetPresentCount(houseNumber); 
	Assert.Equal(expected, result);	
}

[Theory]
[InlineData(4, new []{1, 2, 4})]
void FactorTest(int val, int[] expected) 
{
	int[] result = GetFactors(val);
	Array.Sort(result);
	Assert.Equal(expected, result); 
}