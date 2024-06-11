<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests(); 
	Part1(); 
}

void Part1() 
{
	List<string> strings = GetStrings("input.txt"); 
	int codeLength; 
	int memLength;
	int encodedLength; 
	int accumulatedDifference = 0;
	int accumulatedDifference2 = 0; 
	foreach(string s in strings) 
	{
		(codeLength, memLength, encodedLength) = MeasureString(s);
		//Console.WriteLine($"{s} {codeLength} {memLength} {encodedLength}");
		accumulatedDifference += codeLength - memLength; 
		accumulatedDifference2 += encodedLength - codeLength; 
	}

	Console.WriteLine($"Part 1 accumulated diff: {accumulatedDifference}"); 
	Console.WriteLine($"Part 2 accumulated diff: {accumulatedDifference2}"); 
}


(int codeLength, int memLength, int encodedLength) MeasureString(string value) 
{
	int codeLength = 2; 
	// every string starts and ends with quotes that don't count toward the total mem length
	int memLength = 0;
	
	// part2: encodedLength, every string surrounded by quotes and escaped quotes
	int encodedLength = 6;

	int i = 1;
	//char[] escapes = {'\\', '\"'}; 
	while (i < value.Length - 1)
	{
		char c = value[i];
		if (c == '\\')
		{
			if (i == value.Length - 1) 
			{
				memLength++; 
				codeLength++; 
				encodedLength += 2; 
				i++; 
			}
			else 
			{
				char c2 = value[i + 1];
				if (c2 == '"' || c2 == '\\')
				{
					if (i > 0 && i < value.Length) 
					{
						memLength++; 
					}
					i += 2; 
					codeLength += 2;
					encodedLength += 4; 
				}
				else if (c2 == 'x')
				{
					memLength++;
					i += 4;
					codeLength += 4;
					encodedLength += 5; 
				}
							
			}
		}
		else 
		{
			memLength++; 
			codeLength++; 
			encodedLength++;
			i++; 
		}
	}
	
	return (codeLength, memLength, encodedLength); 
}

static List<string> GetStrings(string fileName) 
{
	List<string> strings = new List<string>();
	string path = Path.Combine(Utility.GetInputDirectory(),fileName);
	using (StreamReader reader = new StreamReader(path)) 
	{
		string line;
		while((line = reader.ReadLine()) != null) 
		{
			strings.Add(line); 
		}
		reader.Close(); 
	}	
	return strings; 
}

/*
"" is 2 characters of code (the two double quotes), but the string contains zero characters.
"abc" is 5 characters of code, but 3 characters in the string data.
"aaa\"aaa" is 10 characters of code, but the string itself contains six "a" characters and a single, escaped 
quote character, for a total of 7 characters in the string data.
"\x27" is 6 characters of code, but the string itself contains just one - an apostrophe ('), escaped using 
hexadecimal notation.
*/
/*
[Theory]
[InlineData("", 2, 0)]
[InlineData("abc", 5, 3)]
[InlineData("aaa\"aaa", 10, 7)]
[InlineData(@"\x27", 6, 1)]
[InlineData("nq", 4, 2)]
void MeasureTest(string s, int expectedCodeLength, int expectedMemLength)
{
	(int codeLength, int memLength) = MeasureString(s); 
	Assert.Equal(expectedCodeLength, codeLength); 
	Assert.Equal(expectedMemLength, memLength); 
}
*/

[Fact]
void SampleTest()
{
	List<string> strings = GetStrings("sample.txt");
	int codeLength;
	int memLength;
	int encLength;

	foreach (string s in strings)
	{
		//Console.WriteLine($"Testing {s}");
		string[] fields = s.Split(',');
		Assert.Equal(fields.Length, 4);
		int ecl = int.Parse(fields[1]);
		int eml = int.Parse(fields[2]);
		int eel = int.Parse(fields[3]);
		(codeLength, memLength, encLength) = MeasureString(fields[0]);
		//Console.WriteLine($"{fields[0]} code: {codeLength} mem: {memLength} enc: {encLength} ec: {ecl} em: {eml} ee: {eel}"); 
		Assert.Equal(ecl, codeLength);
		Assert.Equal(eml, memLength); 
		Assert.Equal(eel, encLength); 
	}



}