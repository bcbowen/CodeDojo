<Query Kind="Program">
  <NuGetReference>System.Security.Cryptography.Algorithms</NuGetReference>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	const string key = "ckczppom";
	Part1(key); 
	Part2(key); 
}

int FindLowestNumber(string key, int prefixLength) 
{
	int i = 0;
	string prefix = new string('0', prefixLength); 
	using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) 
	{
		while (i < int.MaxValue)
		{
			string input = $"{key}{i}"; 
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hashBytes = md5.ComputeHash(inputBytes);
			StringBuilder sb = new StringBuilder();
			for (int j = 0; j < hashBytes.Length; j++)
			{
				sb.Append(hashBytes[j].ToString("X2"));
			}
			string result = sb.ToString();
			if (result.StartsWith(prefix))
			{ 
				Console.WriteLine(result); 
				break;
			}
			i++; 
		}
	}
	
	return i;
	
}

void Part1(string key) 
{
	int result = FindLowestNumber(key, 5);
	Console.WriteLine($"Part1: {result}");
}

void Part2(string key)
{
	int result = FindLowestNumber(key, 6);
	Console.WriteLine($"Part2: {result}");
}

/*
If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...),
and it is the lowest such number to do so.

If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; 
that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....
*/



[Theory]
[InlineData("abcdef", 609043)]
[InlineData("pqrstuv", 1048970)]
void Part1Test(string input, int expected) 
{
	int result = FindLowestNumber(input, 5); 
	Assert.Equal(expected, result); 
}

