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

int GetVisitedHouseCount(string input) 
{
	int x = 0; 
	int y = 0;
	HashSet<(int, int)> visited = new HashSet<(int, int)>();
	visited.Add((0, 0)); 
	foreach (char d in input)
	{
		switch (d) 
		{
			case '^':
				y++;
				break;
			case '>':
				x++; 
				break; 
			case 'v': 
				y--; 
				break; 
			case '<':
				x--; 
				break;
		}
		if (!visited.Contains((x, y)))
		{
			visited.Add((x, y)); 
		}
	}
	
	return visited.Count;
}

int GetPairedVisitedHouseCount(string input)
{
	int x = 0;
	int y = 0;
	int x2 = 0; 
	int y2 = 0; 
	HashSet<(int, int)> visited = new HashSet<(int, int)>();
	visited.Add((0, 0));
	
	for(int i = 0; i < input.Length; i++)
	{
		char d = input[i]; 
		if (i % 2 == 0)
		{
			switch (d)
			{
				case '^':
					y++;
					break;
				case '>':
					x++;
					break;
				case 'v':
					y--;
					break;
				case '<':
					x--;
					break;
			}
			if (!visited.Contains((x, y)))
			{
				visited.Add((x, y));
			}
		}
		else
		{
			switch (d)
			{
				case '^':
					y2++;
					break;
				case '>':
					x2++;
					break;
				case 'v':
					y2--;
					break;
				case '<':
					x2--;
					break;
			}
			if (!visited.Contains((x2, y2)))
			{
				visited.Add((x2, y2));
			}
		}

	}

	return visited.Count;
}

void Part1(string input)
{
	int result = GetVisitedHouseCount(input);
	Console.WriteLine($"Part1 result: {result}"); 
}
void Part2(string input) 
{
	int result = GetPairedVisitedHouseCount(input);
	Console.WriteLine($"Part2 result: {result}");
}

[Theory]
[InlineData(">", 2)]
[InlineData("^>v<", 4)]
[InlineData("^v^v^v^v^v", 2)]
void Part1Test(string input, int expected)
{
	/*
	> delivers presents to 2 houses: one at the starting location, and one to the east.
	^>v< delivers presents to 4 houses in a square, including twice to the house at his starting/ending location.
	^v^v^v^v^v delivers a bunch of presents to some very lucky children at only 2 houses.
	*/
	int result = GetVisitedHouseCount(input); 
	Assert.Equal(expected, result); 
}


[Theory]
[InlineData("^v", 3)]
[InlineData("^>v<", 3)]
[InlineData("^v^v^v^v^v", 11)]
void Part2Test(string input, int expected) 
{
	/*
	^v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
	^>v< now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
	^v^v^v^v^v now delivers presents to 11 houses, with Santa going one direction and Robo-Santa going the other.
	*/
	int result = GetPairedVisitedHouseCount(input);
	Assert.Equal(expected, result);
}