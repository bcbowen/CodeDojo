<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests();  
	int result = SeatingOptimizer.Optimize("input.txt");
	Console.WriteLine($"Part 1 result: {result}"); 
	
	result = SeatingOptimizer.Optimize("input2.txt");
	Console.WriteLine($"Part 2 result: {result}"); 
}

class SeatingOptimizer 
{
	
	public static int Optimize(string fileName)
	{
		List<SeatingChoice> choices = SeatingChoice.Load(fileName); 
		string[] names = choices
			.GroupBy(c => c.Name)
			.Select(c => c.First().Name)
			.ToArray();

		Dictionary<string, int> lookup = choices.ToDictionary(c => $"{c.Name}-{c.Neighbor}", c=> c.Value );
			
		var namePermutations = names.Permutations();
		int maxScore = int.MinValue;
		foreach(var list in namePermutations) 
		{
			int score = GetScore(list.ToArray(), lookup); 
			maxScore = Math.Max(maxScore, score); 
		}
		
		return maxScore;
	}

	private static int GetScore(string[] names, Dictionary<string, int> lookup) 
	{
		int score = 0;
		for(int i = 0; i < names.Length - 1; i++)
		{
			score += lookup[$"{names[i]}-{names[i + 1]}"];
			score += lookup[$"{names[i + 1]}-{names[i]}"]; 
		}

		// wraparound 
		score += lookup[$"{names[0]}-{names[names.Length - 1]}"];
		score += lookup[$"{names[names.Length - 1]}-{names[0]}"];
		
		return score; 
	}	
	
}

class SeatingChoice 
{
	public string Name { get; set; }
	public string Neighbor { get; set; }
	public int Value {get; set;}


	public static List<SeatingChoice> Load(string fileName) 
	{
		List<SeatingChoice> choices = new List<SeatingChoice>(); 
		string path = Path.Combine(Utility.GetInputDirectory(), fileName);
		using (StreamReader reader = new StreamReader(path)) 
		{
			string line; 
			while((line = reader.ReadLine()) != null)
			{
				choices.Add(SeatingChoice.Parse(line)); 
			}
			reader.Close(); 
		}
		
		return choices; 
	}

	public static SeatingChoice Parse(string line) 
	{
		/*
		Alice would lose 2 happiness units by sitting next to David.
		Bob would gain 83 happiness units by sitting next to Alice.
		*/
		string[] fields = line.Split(' '); 
		SeatingChoice choice = new SeatingChoice(); 
		choice.Name = fields[0]; 
		choice.Value = int.Parse(fields[3]); 
		if (fields[2] == "lose") choice.Value *= -1;
		choice.Neighbor = fields[10].TrimEnd('.'); 
		
		return choice;
	}
	
}

[Fact]
void Part1Test() 
{
	int expected = 330; 
	int result = SeatingOptimizer.Optimize("sample.txt"); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData("Alice would lose 2 happiness units by sitting next to David.", "Alice", "David", -2)]
[InlineData("Bob would gain 83 happiness units by sitting next to Alice.", "Bob", "Alice", 83)]
void ParseSeatingChoiceTest(string line, string expectedName, string expectedNeighbor, int expectedValue) 
{
	SeatingChoice choice = SeatingChoice.Parse(line); 
	Assert.Equal(expectedName, choice.Name); 
	Assert.Equal(expectedNeighbor, choice.Neighbor); 
	Assert.Equal(expectedValue, choice.Value); 
}