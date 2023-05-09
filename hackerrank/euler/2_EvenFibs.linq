<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

static long GetEvenFibs(long limit)
{
	long result = 2;
	long next;
	long v1 = 1;
	long v2 = 2;
	while (v2 < limit)
	{
		next = v1 + v2;
		if (next % 2 == 0 && next < limit) result += next;
		v1 = v2;
		v2 = next;
	}
	return result;
}

[Theory]
[InlineData(5, 2)]
[InlineData(20, 10)]
[InlineData(150, 188)]
[InlineData(10, 10)]
[InlineData(100, 44)]
void Test(long limit, long expected)
{
	long result = GetEvenFibs(limit);
	Assert.Equal(expected, result);
}

