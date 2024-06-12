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
	public int Min {get;set;}
	public int Max { get; set; }
	public char RuleChar {get; set;}

	public bool IsValid()
	{
		int count = Password.Count(c => c == RuleChar);
		return count >= Min && count <= Max;
	}

	public static PasswordValidation Parse(string input) 
	{
		PasswordValidation p = new PasswordValidation();
		string[] fields = input.Split(' ');
		if (fields.Length > 2) 
		{
			string[] vals = fields[0].Split('-');
			p.Min = int.Parse(vals[0]);
			p.Max = int.Parse(vals[1]);
			
			p.RuleChar = fields[1][0];
			
			p.Password = fields[2];
		}
		return p;
	}
}