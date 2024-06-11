<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	const string input = "1113222113";
	Part1(input, 40);
	Part1(input, 50); 
	
}

void Part1(string input, int reps) 
{
	string result = input;
	for(int i = 0; i < reps; i++) 
	{
		result = SeeAndSay(result); 
	}

	Console.WriteLine($"Part1: {result.Length}"); 
	
}

string SeeAndSay(string input)
{
	StringBuilder sb = new StringBuilder();

	char c = input[0];
	int count = 1;

	for (int i = 1; i < input.Length; i++)
	{
		if (input[i] == c) 
		{
			count++; 
		}
		else 
		{
			sb.Append(count); 
			sb.Append(c); 
			c = input[i]; 
			count = 1; 
		}
	}
	/*
	int i = 0; 
	char c = input[0];
	int count = 1;
	while (++i < input.Length) 
	{
		if (input[i] != c) 
		{
			sb.Append(count); 
			sb.Append(c); 
			count = 1; 
			c = input[i];
		}
		else 
		{
			count++; 
		}
		i++;
	}*/
	sb.Append(count);
	sb.Append(c); 
	
	return sb.ToString(); 
}


/*
1 becomes 11 (1 copy of digit 1).
11 becomes 21 (2 copies of digit 1).
21 becomes 1211 (one 2 followed by one 1).
1211 becomes 111221 (one 1, one 2, and two 1s).
111221 becomes 312211 (three 1s, two 2s, and one 1).
*/
[Theory]
[InlineData("1", "11")]
[InlineData("11", "21")]
[InlineData("21", "1211")]
[InlineData("1211", "111221")]
[InlineData("111221", "312211")]
void Test(string input, string expected) 
{
	string result = SeeAndSay(input);
	
	Assert.Equal(expected, result);
}
