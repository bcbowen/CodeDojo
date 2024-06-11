<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests(); 
	string[] result = Part1("input.txt").ToArray();
	Console.WriteLine("Part1:"); 
	result.Dump();

	result = Part2("input.txt").ToArray();
	Console.WriteLine("Part2:");
	result.Dump();
}

private IEnumerable<string> Part1(string fileName) 
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] inputs = File.ReadAllLines(path);
	return inputs.WhereMatch("cats: 7")
		.WhereMatch("trees: 3")
		.WhereMatch("pomeranians: 3")
		.WhereMatch("goldfish: 5")
		.WhereMatch("children: 3")
		.WhereMatch("samoyeds: 2")
		.WhereMatch("akitas: 0")
		.WhereMatch("vizslas: 0")
		.WhereMatch("cars: 2")
		.WhereMatch("perfumes: 1"); 
}

private IEnumerable<string> Part2(string fileName)
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] inputs = File.ReadAllLines(path);
	return inputs.WhereMatch("cats: (8|9|10)")
		.WhereMatch("trees: (4|5|6|7|8|9|10)")
		.WhereMatch("pomeranians: [012]")
		.WhereMatch("goldfish: [01234]")
		.WhereMatch("children: 3")
		.WhereMatch("samoyeds: 2")
		.WhereMatch("akitas: 0")
		.WhereMatch("vizslas: 0")
		.WhereMatch("cars: 2")
		.WhereMatch("perfumes: 1");
}


static class Day16Extensions 
{
	public static IEnumerable<string> WhereMatch(this IEnumerable<string> inputs, string pattern) 
	{
		return inputs.Where(i => !i.Contains(pattern.Split(' ')[0]) || Regex.IsMatch(i, pattern)); 
	}
}

[Fact]
void TestPart1() 
{
	string[] result = Part1("sample.txt").ToArray();
	Assert.Equal(1, result.Length);
	result.Dump(); 
}

