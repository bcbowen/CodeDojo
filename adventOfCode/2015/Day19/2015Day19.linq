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

int Part1(string file)
{
	string start = "";
	Dictionary<string, List<string>> replacements = new Dictionary<string, List<string>>();
	string path = Path.Combine(Utility.GetInputDirectory(), file);
	string[] lines = File.ReadAllLines(path);
	string separator = " => ";
	foreach (string line in lines)
	{
		if (line.Contains(separator))
		{
			string[] fields = line.Split(separator);
			if (!replacements.ContainsKey(fields[0]))
			{
				replacements.Add(fields[0], new List<string>());
			}
			replacements[fields[0]].Add(fields[1]);
		}

		start = lines[lines.Length - 1];
	}

	HashSet<string> molecules = new HashSet<string>();

	foreach (string key in replacements.Keys)
	{
		foreach (string value in replacements[key])
		{
			int i = 0;
			while (i > -1)
			{
				i = start.IndexOf(key, i);
				if (i > -1)
				{
					string molecule;
					if (i == 0)
					{
						molecule = value + start.Substring(key.Length);
					}
					else
					{
						molecule = start.Substring(0, i) + value + start.Substring(i + key.Length);
					}
					if (!molecules.Contains(molecule)) molecules.Add(molecule);
					i++;
				}

			}

		}
	}
	int count = molecules.Count;
	Console.WriteLine($"Part 1 for {file}: {count}");
	return count;
}


int Part2(string file)
{

	string molecule = "";
	Dictionary<string, string> replacements = new Dictionary<string, string>();
	string path = Path.Combine(Utility.GetInputDirectory(), file);
	string[] lines = File.ReadAllLines(path);
	string separator = " => ";
	foreach (string line in lines)
	{
		if (line.Contains(separator))
		{
			string[] fields = line.Split(separator);
			replacements.Add(fields[1], fields[0]);
		}

		molecule = lines[lines.Length - 1];
	}

	int count = 0;

	while (!molecule.Equals("e"))
	{
		foreach (string key in replacements.Keys)
		{
			int pos = molecule.LastIndexOf(key);
			if (pos > -1)
			{
				if (pos == 0)
				{
					molecule = replacements[key] + molecule.Substring(key.Length);
				}
				else
				{
					molecule = molecule.Substring(0, pos) + replacements[key] + molecule.Substring(pos + key.Length);
				}
				count++; 
				
			}
		}
		if (count > 100000) break; 
	}
	
	Console.WriteLine($"Part 2 for {file}: {count}");
	return count;
}

[Fact]
void Part1Test()
{
	int expected = 4;
	int result = Part1("sample.txt");
	Assert.Equal(expected, result);
}

