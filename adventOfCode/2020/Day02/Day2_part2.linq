<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	int validCount = 0;
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	using (StreamReader reader = new StreamReader(path))
	{
		string line;
		while ((line = reader.ReadLine()) != null)
		{
			PasswordValidation p = PasswordValidation.Parse(line);
			Console.WriteLine(p.ToString()); 
			if (p.IsValid())
			{
				validCount++;
			}

		}
		reader.Close();
	}

	Console.WriteLine($"validCount: {validCount}");

}

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