<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Part1("input.txt");
	Part2("input.txt");
}

// You can define other methods, fields, classes and namespaces here
/*
The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 
green cubes, and 14 blue cubes?
*/

int Part1(string fileName)
{
	int redCount = 12;
	int greenCount = 13;
	int blueCount = 14;

	List<Game> games = Game.LoadGames(fileName);

	int counts = games
		.Where(g => g.ColorMaxes["red"] <= redCount &&
			g.ColorMaxes["green"] <= greenCount &&
			g.ColorMaxes["blue"] <= blueCount).Sum(g => g.Id);

	Console.WriteLine($"Part 1: {counts}");
	return counts;
}

int Part2(string fileName)
{
	List<Game> games = Game.LoadGames(fileName);
	int result = Game.GetGamesPower(games);
	Console.WriteLine($"Part 2: {result}");
	return result;
}

class Game
{
	/*
	Game 1: 19 blue, 12 red; 19 blue, 2 green, 1 red; 13 red, 11 blue
	*/
	public int Id { get; set; }
	public Dictionary<string, int> ColorMaxes { get; set; } = new Dictionary<string, int>();
	public int GetMinPower()
	{
		int power = 1;
		foreach (int value in ColorMaxes.Values)
		{
			power *= value;
		}
		return power;
	}

	public static int GetGamesPower(List<Game> games)
	{
		int sum = 0;
		foreach (Game game in games)
		{
			sum += game.GetMinPower();
		}
		return sum;
	}

	public static Game Parse(string line)
	{
		Game game = new Game();
		//Dictionary<string, int> maxes = new Dictionary<string, int>(); 
		//string pattern = @"(?<name>[A-Za-z]+): capacity (?<capacity>[-\d]+), durability (?<durability>[-\d]+), flavor (?<flavor>[-\d]+), texture (?<texture>[-\d]+), calories (?<calories>[-\d]+)";
		string[] fields = line.Split(':');
		game.Id = int.Parse(fields[0].Substring(5));

		string[] draws = fields[1].Split(';');
		foreach (string draw in draws)
		{
			string[] chipCounts = draw.Split(',');
			foreach (string count in chipCounts)
			{
				string[] details = count.Trim().Split(' ');
				int value = int.Parse(details[0]);
				if (!game.ColorMaxes.ContainsKey(details[1]))
				{
					game.ColorMaxes.Add(details[1], value);
				}
				else
				{
					game.ColorMaxes[details[1]] = Math.Max(game.ColorMaxes[details[1]], value);
				}

			}
		}

		return game;
	}

	public static List<Game> LoadGames(string fileName)
	{
		List<Game> games = new List<Game>();
		string path = Path.Combine(Utility.GetInputDirectory(), fileName);
		using (StreamReader reader = new StreamReader(path))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				games.Add(Game.Parse(line));
			}
			reader.Close();
		}

		return games;
	}


}

/*
Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 13: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
*/
[Theory]
[InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, 6, 4, 2)]
[InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2, 4, 1, 3)]
[InlineData("Game 13: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 13, 6, 20, 13)]
void ParseMaxTest(string line, int expectedId, int expectedBlue, int expectedRed, int expectedGreen)
{

	Game game = Game.Parse(line);
	Assert.Equal(expectedId, game.Id);
	Assert.Equal(expectedBlue, game.ColorMaxes["blue"]);
	Assert.Equal(expectedRed, game.ColorMaxes["red"]);
	Assert.Equal(expectedGreen, game.ColorMaxes["green"]);
}


[Fact]
void Part1Test()
{
	int expected = 8;
	int result = Part1("sample.txt");
	Assert.Equal(expected, result);
}

[Fact]
void Part2Test()
{
	int expected = 2286;
	int result = Part2("sample.txt");
	Assert.Equal(expected, result);
}