<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	//string path = Path.Combine(Utility.GetInputDirectory(), "SampleValid.txt";
	//string path = Path.Combine(Utility.GetInputDirectory(), "SampleInvalid.txt";
	int validCount = 0;
	
	using (StreamReader reader = new StreamReader(path))
	{
		string line = ""; 
		PassportValidator validator = new PassportValidator(); 
		while ((line = reader.ReadLine()) != null)
		{
			if (line == "")
			{
				if (validator.IsValid()) validCount ++; 
				Console.WriteLine(validator.ToString()); 
				validator = new PassportValidator();
			}
			else
			{
				validator.AddValidationInput(line);
			}
		}
		
		if (validator.IsValid()) validCount++;
		Console.WriteLine(validator.ToString()); 
		validator = new PassportValidator();
		
		reader.Close();
	}

	Console.WriteLine($"validCount: {validCount}");

}

class PassportValidator
{
	public int BirthYear { get; set; }
	public int IssueYear { get; set; }
	public int ExpirationYear { get; set; }
	public string Height { get; set; }
	public string HairColor { get; set; }
	public string EyeColor { get; set; }
	public string PassportId { get; set; }
	public string CountryId { get; set; }
	public string ValidationErrors { get; private set;}

	public bool IsValid()
	{
		ValidationErrors = ""; 
		
		bool valid = true;
		StringBuilder validationErrors = new StringBuilder(); 
		if (BirthYear < 1920 || BirthYear > 2002)
		{
			valid = false;	
			validationErrors.Append("byr;");
		}

		if (IssueYear < 2010 || IssueYear > 2020)
		{
			valid = false;
			validationErrors.Append("iyr;"); 
		}

		if (ExpirationYear < 2020 || ExpirationYear > 2030)
		{
			valid = false;
			validationErrors.Append("eyr;");
		}

		if (!IsHeightValid())
		{
			valid = false;
			validationErrors.Append("hgt;");
		}

		string pattern = "#[0-9a-f]{6}";
		if (string.IsNullOrEmpty(HairColor) || !Regex.IsMatch(HairColor, pattern))
		{
			valid = false;
			validationErrors.Append("hcl;");
		}

		if (string.IsNullOrEmpty(EyeColor) || !new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(EyeColor))
		{
			valid = false;
			validationErrors.Append("ecl;");
		}

		pattern = @"^\d{9}$"; 
		if (string.IsNullOrEmpty(PassportId) || !Regex.IsMatch(PassportId, pattern)) 
		{
			valid = false;
			validationErrors.Append("pid;");
		}

		if (!valid) 
		{
			ValidationErrors = validationErrors.ToString(); 
		}
		
		return valid;
	}

	private bool IsHeightValid() 
	{
		if (Height == null) return false;
		//Console.WriteLine($"Height validation {Height}");
		int max, min;
		if (Height.EndsWith("in"))
		{ 
			min = 59; 
			max = 76;
		}
		else if (Height.EndsWith("cm")) 
		{
			min = 150; 
			max = 193;
		}
		else 
		{
			//Console.WriteLine("Height not in expected format");
			return false;
		}

		int height;
		if (int.TryParse(Height.Substring(0, Height.Length - 2), out height)) 
		{
			bool valid = height >= min && height <= max;
			//Console.WriteLine($"Height Valid: {valid}"); 
			return valid;
		}
		else 
		{
			//Console.WriteLine("Unable to parse height value"); 
			return false;
		}
	}

	public void AddValidationInput(string input) 
	{
		string[] properties = input.Split(' ');
		foreach (string property in properties)
		{
			string[] fields = property.Split(':');
			switch(fields[0]) 
			{
				case "byr":
					BirthYear = int.Parse(fields[1]);
					break;
				case "iyr":
					IssueYear = int.Parse(fields[1]);
					break;
				case "eyr":
					ExpirationYear = int.Parse(fields[1]);
					break;
				case "hgt":
					Height = fields[1];
					break;
				case "hcl":
					HairColor = fields[1];
					break;
				case "ecl":
					EyeColor = fields[1];
					break;
				case "pid":
					PassportId = fields[1];
					break;
				case "cid":
					CountryId = fields[1];
					break;
			}
		}
		
	}

	public override string ToString()
	{
		return $"byr: {BirthYear}; iyr: {IssueYear}; eyr: {ExpirationYear}; hgt: {Height}; hcl: {HairColor}; ecl: {EyeColor}; pid: {PassportId}; IsValid: {IsValid()}; ValidationErrors: {ValidationErrors}";
	}
}
