<Query Kind="Program">
  <Namespace>Xunit</Namespace>
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
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string value = File.ReadAllText(path);
	string result = Decompress(value);
	Console.WriteLine($"Part1 len: {result.Length}"); 
}

void Part2()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string value = File.ReadAllText(path);
	long result = Decompress2Len(value);
	Console.WriteLine($"Part2 len: {result}");
}

/// <summary>
/// Return values: 
///  start: Index of first char after marker
///  end: Index of last char covered by marker or last char in string
///  multiplier: multiplier for marker
/// </summary>
(int start, int end, int multiplier) GetMarker(string line, int start)
{
	int end = start + 1;
	while (line[end] != ')') 
	{
		end++; 
	}
	string value = line.Substring(start + 1, end - start - 1); 
	string[] fields = value.Split('x');
	int length = int.Parse(fields[0]);
	int multiplier = int.Parse(fields[1]); 
	
	// set return values: 
	start = end + 1; 
	end = Math.Min(start + length - 1, line.Length - 1); 
	return (start, end, multiplier); 
}

long Decompress2Len(string value) 
{
	List<(int start, int end, int multiplier)> markers = new List<(int start, int end, int multiplier)>();
	int index = 0;
	//int nextValue = 1;
	bool inMarker = false;
	long length = 0; 
	while (index < value.Length)
	{
		if (value[index] == '(') 
		{
			inMarker = true; 
			markers.Add(GetMarker(value, index));
		}
		
		int nextValue = 1; 
		for (int i = markers.Count() - 1; i >= 0; i--) 
		{
			(int s, int e, int m) marker = markers[i];
			if (marker.s <= index) 
			{
				nextValue *= marker.m; 
			}
			
			if (index == marker.e) markers.Remove(marker);
		}
		if (!inMarker)
		{
			length += nextValue;
		}
		if (value[index] == ')')
		{
			// turn this off after adding next value becasue we don't want to start counting until the following character
			inMarker = false;
		}
		index++;
	}
	
	return length; 
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
void Test_Part1(string input, string expected) 
{
	string result = Decompress(input); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData("A(1x5)BC", 1, 6, 6, 5)]
[InlineData("(3x3)XYZ", 0, 5, 7, 3)]
[InlineData("A(2x2)BCD(2x2)EFG", 1, 6, 7, 2)]
[InlineData("A(2x2)BCD(2x2)EFG", 9, 14, 15, 2)]
[InlineData("(6x1)(1x3)A", 0, 5, 10, 1)]
[InlineData("(6x1)(1x3)A", 5, 10, 10, 3)]
[InlineData("X(8x2)(3x3)ABCY", 1, 6, 13, 2)]
[InlineData("X(8x2)(3x3)ABCY", 6, 11, 13, 3)]
void Test_GetMarker(string input, int start, int expectedStart, int expectedEnd, int expectedMultiplier)
{
	(int s, int e, int m) result = GetMarker(input, start);
	Assert.Equal((expectedStart, expectedEnd, expectedMultiplier), result);
}

/*
(3x3)XYZ still becomes XYZXYZXYZ, as the decompressed section contains no markers.
X(8x2)(3x3)ABCY becomes XABCABCABCABCABCABCY, because the decompressed data from the (8x2) marker is then further decompressed, thus triggering the (3x3) marker twice for a total of six ABC sequences.
(27x12)(20x12)(13x14)(7x10)(1x12)A decompresses into a string of A repeated 241920 times.
(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN becomes 445 characters long.
*/
[Theory]
[InlineData("(3x3)XYZ", 9)]
[InlineData("X(8x2)(3x3)ABCY", 20)]
[InlineData("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
[InlineData("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
public void Test_Part2(string value, long expected)
{
	long result = Decompress2Len(value); 
	Assert.Equal(expected, result); 
	
}