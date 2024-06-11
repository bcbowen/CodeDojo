<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests(); 
}

[Fact]
void Part1()
{
	List<Ingredient> ingredients = Ingredient.Load("input.txt");
	int result = Ingredient.Maximize4Ingredients(ingredients);
	Console.WriteLine($"Result: {result}"); 
}

class Ingredient
{
	public string Name { get; set; }
	public int Capacity { get; set; }
	public int Durability { get; set; }
	public int Flavor { get; set; }
	public int Texture { get; set; }
	public int Calories { get; set; }

	public static List<Ingredient> Load(string fileName)
	{
		string path = Path.Combine(Utility.GetInputDirectory(), fileName);
		List<Ingredient> ingredients = new List<Ingredient>();
		using (StreamReader reader = new StreamReader(path))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				ingredients.Add(Ingredient.Parse(line));
			}
			reader.Close();
		}

		return ingredients;
	}

	public static Ingredient Parse(string value)
	{
		string pattern = @"(?<name>[A-Za-z]+): capacity (?<capacity>[-\d]+), durability (?<durability>[-\d]+), flavor (?<flavor>[-\d]+), texture (?<texture>[-\d]+), calories (?<calories>[-\d]+)";

		// Use the regex to match the pattern in the input string
		Match match = Regex.Match(value, pattern);
		Ingredient ingredient;
		if (match.Success)
		{
			ingredient = new Ingredient
			{
				Name = match.Groups["name"].Value,
				Capacity = int.Parse(match.Groups["capacity"].Value),
				Durability = int.Parse(match.Groups["durability"].Value),
				Flavor = int.Parse(match.Groups["flavor"].Value),
				Texture = int.Parse(match.Groups["texture"].Value),
				Calories = int.Parse(match.Groups["calories"].Value)
			};

		}
		else
		{
			throw new ArgumentException($"Unable to parse ingredient from string: {value}", "value");
		}

		return ingredient;
	}

	public static int Maximize2Ingredients(List<Ingredient> ingredients)
	{
		int max = 0;
		foreach(int[] combo in Distribute2()) 
		{
			max = Math.Max(max, GetScore(ingredients, combo));
		}
		return max;
	}

	public static int Maximize4Ingredients(List<Ingredient> ingredients)
	{
		int max = 0;
		foreach (int[] combo in Distribute4())
		{
			max = Math.Max(max, GetScore(ingredients, combo));
		}
		return max;
	}

	// part2: only score recipes with a total calorie count of 500
	static int GetScore(List<Ingredient> ingredients, int[] parts)
	{
		Ingredient combined = new Ingredient();
		int CalorieCount = 0; 
		
		for(int i = 0; i < ingredients.Count; i++)
		{
			CalorieCount += ingredients[i].Calories * parts[i];
			combined.Capacity += ingredients[i].Capacity * parts[i]; 
			combined.Durability += ingredients[i].Durability * parts[i]; 
			combined.Flavor += ingredients[i].Flavor * parts[i]; 
			combined.Texture += ingredients[i].Texture * parts[i]; 
		}
		
		combined.Capacity = Math.Max(combined.Capacity, 0);
		combined.Durability = Math.Max(combined.Durability, 0);
		combined.Flavor = Math.Max(combined.Flavor, 0);
		combined.Texture = Math.Max(combined.Texture, 0);

		if (CalorieCount == 500) 
		{
			return combined.Capacity * combined.Durability * combined.Flavor * combined.Texture;
		}
		else
		{
			return 0;
		}
		
	}

	/*
	
		0 0 0 5
		0 0 1 4
		0 1 0 4
		1 0 0 4
		0 0 2 3
		0 2 0 3
		2 0 0 3
		0 1 1 3
		1 1 0 3
		0 0 3 2
		0 3 0 2
		3 0 0 2
		0 1 2 2
		1 2 0 2
		2 1 0 2
		1 1 1 2
		0 0 3 2
		0 0 4 1
		0 0 5 0 
		
		
	
	*/

	internal static IEnumerable<int[]> Distribute4()
	{
		int max = 100; 
		for (int i = 0; i <= max; i++)
		for (int j = 0; j <= max - i; j++)
		for (int k = 0; k <= max - j - i; k++)
		yield return new[] { i, j, k, 100 - i - j - k };	
	}


	internal static IEnumerable<int[]> Distribute2()
	{
		for (int i = 100; i >= 0; i--)
		{
			yield return new[] {i, 100 - i};
		}
	}

	internal static IEnumerable<(int, int)> Get2Factors()
	{
		for (int i = 1; i < 100; i++) 
		{
			yield return (i, 100 - i); 
		}
	}
}

[Fact] 
void ParseTest() 
{
	string value = "Candy: capacity 0, durability -1, flavor 0, texture 5, calories 8"; 
	Ingredient i = Ingredient.Parse(value); 
	Assert.Equal("Candy", i.Name); 
	Assert.Equal(0, i.Capacity); 
	Assert.Equal(-1, i.Durability); 
	Assert.Equal(0, i.Flavor); 
	Assert.Equal(5, i.Texture); 
	Assert.Equal(8, i.Calories); 
}

[Fact]
void TestPart1() 
{
	List<Ingredient> ingredients = Ingredient.Load("sample.txt");
	int expected = 57600000;
	int result = Ingredient.Maximize2Ingredients(ingredients);
	Assert.Equal(expected, result);
}

