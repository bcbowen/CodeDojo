<Query Kind="Program">
  <Namespace>Xunit</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests();
	Part1();
	Part2(); 
}

void Part1() 
{
	string code = "cxdnnyjw";
	string password = GeneratePassword(code);
	Console.WriteLine($"Part1: {password}"); 
}

void Part2()
{
	string code = "cxdnnyjw";
	string password = GeneratePassword2(code);
	Console.WriteLine($"Part2: {password}");
}


/*
The first index which produces a hash that starts with five zeroes is 3231929, which we find by hashing abc3231929; the sixth 
character of the hash, and thus the first character of the password, is 1.
5017308 produces the next interesting hash, which starts with 000008f82
*/
string GeneratePassword(string code) 
{
	StringBuilder password = new StringBuilder();
	int counter = 0;
	while (password.Length < 8)
	{
		string hash = GenerateHash($"{code}{counter}");
		if (hash.StartsWith("00000"))
		{
			password.Append(hash[5]);
		}
		counter++; 
	}
	
	return password.ToString().ToLower(); 
}

string GeneratePassword2(string code)
{
	StringBuilder password = new StringBuilder("--------");
	int counter = 0;
	while (password.ToString().Contains('-'))
	{
		string hash = GenerateHash($"{code}{counter}");
		if (hash.StartsWith("00000"))
		{
			string si = hash.Substring(5, 1);
			int index;
			if (int.TryParse(si, out index) && index >= 0 && index < 8 && password[index] == '-')
			{
				password[index] = hash[6];
			}
			
		}
		counter++;
	}

	return password.ToString().ToLower();
}

string GenerateHash(string value) 
{
	byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(value);
	byte[] hashBytes = MD5.HashData(inputBytes);
	return Convert.ToHexString(hashBytes);
}

/// <summary>
/// Should result in hash starting with 6 0s
/// </summary>
[Theory]
[InlineData("abc3231929")]
[InlineData("abc5017308")]
void HashTest(string input) 
{
	string hash = GenerateHash(input); 
	Assert.True(hash.StartsWith("00000"));
}

[Theory]
[InlineData("abc", "18f47a30")]
void TestPasswordPart1(string code, string expected) 
{
	string result = GeneratePassword(code); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData("abc", "05ace8e3")]
void TestPasswordPart2(string code, string expected)
{
	string result = GeneratePassword2(code);
	Assert.Equal(expected, result);
}