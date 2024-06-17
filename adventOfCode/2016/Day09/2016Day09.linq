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
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string value = File.ReadAllText(path);
	string result = Decompress(value);
	Console.WriteLine($"Part1 len: {result.Length}"); 
}

string Decompress(string value) 
{
	StringBuilder result = new StringBuilder(); 
	int pos = 0;
	int pos2 = 0; 
	int repeatChars; 
	int repetitions; 
	while(pos < value.Length)
	{
		if (value[pos] != '(') 
		{
			result.Append(value[pos]); 
			pos++; 
		}
		else 
		{
			pos2 = pos + 1;
			while (value[pos2] != ')') 
			{
				pos2++; 	
			}
			string marker = value.Substring(pos + 1, pos2 - pos - 1); 
			string[] fields = marker.Split('x');
			repeatChars = int.Parse(fields[0]); 
			repetitions = int.Parse(fields[1]);
			string section = value.Substring(pos2 + 1, repeatChars);
			for (int i = 0; i < repetitions; i++) 
			{
				result.Append(section); 
			}
			pos2 += repeatChars + 1; 
			pos = pos2; 
		}
	}
	
	return result.ToString(); 
}

/*
ADVENT contains no markers and decompresses to itself with no changes, resulting in a 
decompressed length of 6.
A(1x5)BC repeats only the B a total of 5 times, becoming ABBBBBC for a decompressed length 
of 7.
(3x3)XYZ becomes XYZXYZXYZ for a decompressed length of 9.
A(2x2)BCD(2x2)EFG doubles the BC and EF, becoming ABCBCDEFEFG for a decompressed length of 11.
(6x1)(1x3)A simply becomes (1x3)A - the (1x3) looks like a marker, but because it's within a
 data section of another marker, it is not treated any differently from the A that comes after
  it. It has a decompressed length of 6.
X(8x2)(3x3)ABCY becomes X(3x3)ABC(3x3)ABCY (for a decompressed length of 18), because the
 decompressed data from the (8x2) marker (the (3x3)ABC)
*/

[Theory]
[InlineData("ADVENT", "ADVENT")]
[InlineData("A(1x5)BC", "ABBBBBC")]
[InlineData("(3x3)XYZ", "XYZXYZXYZ")]
[InlineData("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG")]
[InlineData("(6x1)(1x3)A", "(1x3)A")]
[InlineData("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY")]
void Test(string input, string expected) 
{
	string result = Decompress(input); 
	Assert.Equal(expected, result); 
}
