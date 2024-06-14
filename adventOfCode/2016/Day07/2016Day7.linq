<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities"
void Main()
{
	RunTests();
	Part1();
	Part2();
}

void Part1()
{
	int result = CountSupportingIps("input.txt");
	Console.WriteLine($"Part 1 count: {result}");
}

void Part2()
{
	int result = CountSSLSupport("input.txt");
	Console.WriteLine($"Part 2 count: {result}");
}

int CountSupportingIps(string fileName)
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	int count = 0;
	foreach (string line in lines)
	{
		if (SupportsTLS(line)) count++;
	}

	return count;
}

int CountSSLSupport(string fileName) 
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	int count = 0;
	foreach (string line in lines)
	{
		if (SupportsSSL(line)) count++;
	}

	return count;
}

// has 4-character sequence like xyyx outside of square brackets
// any 4-character sequence like xyyx returns false 
bool SupportsTLS(string ip)
{
	bool hypernetMode = false;
	bool isSupported = false;
	for (int i = 0; i < ip.Length - 3; i++)
	{
		if (ip[i] == '[') hypernetMode = true;
		else if (ip[i] == ']') hypernetMode = false;
		else
		{
			// check for ABBA sequence
			if (ip[i] == ip[i + 3] && ip[i] != ip[i + 1] && ip[i + 1] == ip[i + 2])
			{
				if (hypernetMode)
				{
					return false;
				}
				else
				{
					isSupported = true;
				}
			}
		}
	}
	return isSupported;
}

// has 3-character sequence like xyx outside of square brackets ABA
// AND reverse 3-char sequence inside like yxy (must be inverse) BAB
bool SupportsSSL(string ip)
{
	bool hypernetMode = false;
	HashSet<string> Abas = new HashSet<string>();
	HashSet<string> Babs = new HashSet<string>();
	for (int i = 0; i < ip.Length - 2; i++)
	{
		if (ip[i] == '[') hypernetMode = true;
		else if (ip[i] == ']') hypernetMode = false;
		else
		{
			string val = ip.Substring(i, 3);
			// check for XYX sequence
			if (val[0] == val[2] && val[0] != val[1])
			{
				if (hypernetMode)
				{
					Babs.Add(val);
				}
				else
				{
					Abas.Add(val);
				}
			}
		}
	}
	foreach (string aba in Abas)
	{
		string bab = new String(new[] { aba[1], aba[0], aba[1] });
		if (Babs.Contains(bab)) return true;
	}
	return false;
}

[Theory]
[InlineData("abba[mnop]qrst", true)]
[InlineData("abcd[bddb]xyyx", false)]
[InlineData("aaaa[qwer]tyui", false)]
[InlineData("ioxxoj[asdfgh]zxcvbn", true)]
void SupportTLSTest(string value, bool expected)
{
	bool result = SupportsTLS(value);
	Assert.Equal(expected, result);
}


[Theory]
[InlineData("aba[bab]xyz", true)]
[InlineData("xyx[xyx]xyx", false)]
[InlineData("aaa[kek]eke", true)]
[InlineData("zazbz[bzb]cdb", true)]
void SupportsSSLTest(string value, bool expected)
{
	
}

[Fact]
void Test()
{
	int expected = 2;
	int result = CountSupportingIps("sample.txt");
	Assert.Equal(expected, result);
}