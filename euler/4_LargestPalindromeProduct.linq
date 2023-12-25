<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
	int result = GetLargestPalindromeProduct(3);
	Console.WriteLine($"Result: {result}"); 
}

int GetLargestPalindromeProduct(int digits) 
{
	if (digits < 1 || digits > 3) throw new ArgumentOutOfRangeException("Let's not get carried away here"); 
	int limit = (int)Math.Pow(10, digits); 
	int step = limit / 10; 
	limit--; 

	int j = limit;
	int currentStep = limit - step;
	while(currentStep > 0)
	{
		while(limit > currentStep)
		{
			while (j > currentStep)
			{
				int product = limit * j;

				if (IsPalindrome(product))
				{
					Console.WriteLine($"limit: {limit} j: {j}"); 
					return product; 	
				}
				
				j--; 
			}
			limit--; 
			j = limit; 
			
		}
		currentStep -= step; 
	}
	
	return 0; 
}

bool IsPalindrome(int val) 
{
	string s = val.ToString(); 
	if (s.Length == 1) return true; 
	int l = 0;
	int r = s.Length - 1;
	while (r > l) 
	{
		if (s[l] != s[r]) return false; 
		l++; 
		r--; 
	}
	return true;
}


[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(9009, true)]
[InlineData(909, true)]
[InlineData(99, true)]
[InlineData(9, true)]
[InlineData(90019, false)]
void IsPalindromeTest(int val, bool expected) 
{
	bool result = IsPalindrome(val); 
	Assert.Equal(expected, result); 
}

[Fact]
void Test()
{
	int expected = 9009; 
	int result = GetLargestPalindromeProduct(2); 
	Assert.Equal(expected, result); 
}