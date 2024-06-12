<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	int validCount = 0;
	
	using (StreamReader reader = new StreamReader(path))
	{
		string line = ""; 
		PassportValidator validator = null; 
		while ((line = reader.ReadLine()) != null)
		{
			if (validator == null)
			{
				validator = new PassportValidator();
			}
			else if (line == "")
			{
				if (validator.IsValid()) validCount ++; 
				validator = new PassportValidator();
			}
			else
			{
				validator.AddValidationInput(line);
			}
		}
		
		if (validator.IsValid()) validCount++;
		validator = new PassportValidator();
		
		reader.Close();
	}

	Console.WriteLine($"validCount: {validCount}");

}

class PassportValidator
{
	public bool HasBirthYear { get; set; }
	public bool HasIssueYear { get; set; }
	public bool HasExpirationYear { get; set; }
	public bool HasHeight { get; set; }
	public bool HasHairColor { get; set; }
	public bool HasEyeColor { get; set; }
	public bool HasPassportId { get; set; }
	public bool HasCountryId { get; set; }

	public bool IsValid()
	{
		return HasBirthYear && 
			HasIssueYear && 
			HasExpirationYear && 
			HasHeight && 
			HasHairColor && 
			HasEyeColor && 
			// HasCountryId && 
			HasPassportId;
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
					HasBirthYear = true;
					break;
				case "iyr":
					HasIssueYear = true;
					break;
				case "eyr":
					HasExpirationYear = true;
					break;
				case "hgt":
					HasHeight = true;
					break;
				case "hcl":
					HasHairColor = true;
					break;
				case "ecl":
					HasEyeColor = true;
					break;
				case "pid":
					HasPassportId = true;
					break;
				case "cid":
					HasCountryId = true;
					break;
			}
		}
		
	}
}
