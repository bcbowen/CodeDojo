<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	RunTests();
}

// You can define other methods, fields, classes and namespaces here
[Theory]
[InlineData(1, 1)] 
[InlineData(12, 3)]
[InlineData(123, 6)]
[InlineData(1234, 10)]
[InlineData(12345, 15)]
[InlineData(10, 1)]
[InlineData(100, 1)]
[InlineData(1001, 2)]
[InlineData(40001, 5)]
[InlineData(401000, 5)]
void SumDigitsTest(int val, int expected) 
{
	int actual = SumDigits(val);
	Assert.Equal(expected, actual);
}

[Theory]
[InlineData(1, new[] {1})]
[InlineData(12, new[] {1, 2})]
[InlineData(123, new[] {1, 2, 3})]
[InlineData(1234, new[] {1,2,3,4})]
[InlineData(12345, new[] {1,2,3,4,5})]
void GetDigitsTest(int value, int[] expected) 
{
	int[] result = GetDigits(value);
	for (int i = 0; i < result.Length; i++)
	{
		Assert.Equal(expected[i], result[i]);
	}
}

[Theory]
[InlineData(234, 24)]
[InlineData(4421, 32)]
void ProductDigitsTest(int value, long expected) 
{
	long result = ProductDigits(value); 
	Assert.Equal(expected, result);
}

int SumDigits(int val) 
{
	int[] digits = GetDigits(val);
	return digits.Sum(d => d);
}

long ProductDigits(int val) 
{
	int[] digits = GetDigits(val);
	long product = 1;
	foreach(int digit in digits) 
	{
		product *= digit;
	}
	return product;
}

int[] GetDigits(int val) 
{
	List<int> digits = new List<int>();
	while (val > 0)
	{
		digits.Add(val % 10);
		val /= 10;
	}
	digits.Reverse();
	return digits.ToArray();
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion