<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	const int x = 3; 
	int treeCount = 0;
	using (StreamReader reader = new StreamReader(path))
	{
		
		string line = reader.ReadLine();
		int length = line.Length;
		int index = 0;
		if (line[index] == '#') treeCount++;
		while ((line = reader.ReadLine()) != null)
		{
			index = (index + x) % length;
			if (line[index] == '#') treeCount++;
		}
		reader.Close();
	}

	Console.WriteLine($"treeCount: {treeCount}");

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