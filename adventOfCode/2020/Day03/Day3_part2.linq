<Query Kind="Program" />

void Main()
{
	Slope[] slopes = new Slope[]
	{
		new Slope {X = 1, Y = 1},
		new Slope {X = 3, Y = 1},
		new Slope {X = 5, Y = 1},
		new Slope {X = 7, Y = 1},
		new Slope {X = 1, Y = 2}
	};

	int product = 1;
	foreach(Slope slope in slopes) 
	{
		product *= calculateTreeCount(slope);
	}

	Console.WriteLine($"product: {product}");

}

struct Slope 
{
	public int X { get; set; }
	public int Y { get; set; }
}

int calculateTreeCount(Slope slope)
{
	const string path = @"C:\dev\adventOfCode\Day3\inputs.txt";
	//const string path = @"C:\dev\adventOfCode\Day3\sample.txt";
	int treeCount = 0;
	bool done = false;
	bool first = true;
	using (StreamReader reader = new StreamReader(path))
	{
		int index = 0;
		while (!done)
		{
			string line = ""; 
			for (int i = 0; i < (first ? 1 : slope.Y); i++) 
			{
				line = reader.ReadLine();
				if (line == null) 
				{
					done = true;
					break;
				}
			}
			if (!done)
			{
				if (line[index] == '#') treeCount++;
				index = (index + slope.X) % line.Length;
			}
			first = false;
		}
		
		reader.Close();
	}
	Console.WriteLine($"Treecount for {slope.X}, {slope.Y}: {treeCount}");
	return treeCount;
}


/*
class PasswordValidation 
{
	public string Password { get; set; }
	public int Position1 {get;set;}
	public int Position2 { get; set; }
	public char RuleChar {get; set;}

	public bool IsValid()
	{
		if (Password.Length < Position2) return false;
		
		return Password[Position1 - 1] == RuleChar ^ Password[Position2 - 1] == RuleChar;
	}

	public static PasswordValidation Parse(string input) 
	{
		PasswordValidation p = new PasswordValidation();
		string[] fields = input.Split(' ');
		if (fields.Length > 2) 
		{
			string[] vals = fields[0].Split('-');
			p.Position1 = int.Parse(vals[0]);
			p.Position2 = int.Parse(vals[1]);
			
			p.RuleChar = fields[1][0];
			
			p.Password = fields[2];
		}
		return p;
	}

	public override string ToString()
	{
		return $"{Password} {RuleChar} [{Position1} | {Position2}] IsValid: {IsValid()}";
	}
}
*/