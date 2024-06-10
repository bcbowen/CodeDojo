<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string input = File.ReadAllText(path);
	Part1(input); 
	Part2(input);
}

int SantaElevator(string input) 
{
	int result = 0;
	foreach (char c in input) 
	{
		switch (c)
		{
			case '(':
				result++;
				break;
			case ')':
				result--;
				break;
		}
	}
	return result; 
}

int SantaBasement(string input)
{
	int result = 0;
	int position = 0; 
	foreach (char c in input)
	{
		position++; 
		switch (c)
		{
			case '(':
				result++;
				break;
			case ')':
				result--;
				break;
		}
		if (result < 0) return position; 
	}
	return -1;
}
/*
private string GetQueryDirectory()
{
	FileInfo file = new FileInfo(Util.CurrentQueryPath);
	return file.DirectoryName;
}
*/


/*
(()) and ()() both result in floor 0.
((( and (()(()( both result in floor 3.
))((((( also results in floor 3.
()) and ))( both result in floor -1 (the first basement level).
))) and )())()) both result in floor -3.
*/

[Theory]
[InlineData("(())", 0)]
[InlineData("()()", 0)]
[InlineData("(((", 3)]
[InlineData("(()(()(", 3)]
[InlineData("))(((((", 3)]
[InlineData("())", -1)]
[InlineData("))(", -1)]
[InlineData(")))", -3)]
[InlineData(")())())", -3)]
void Part1Test(string input, int expected) 
{
	int result = SantaElevator(input); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData(")", 1)]
[InlineData("()())", 5)]
void Part2Test(string input, int expected)
{
	int result = SantaBasement(input);
	Assert.Equal(expected, result);
}

void Part1(string input)
{
	int result = SantaElevator(input);
	Console.WriteLine($"Part 1 output: {result}"); 
}

void Part2(string input) 
{
	int result = SantaBasement(input);
	Console.WriteLine($"Part 2 output: {result}");
}
