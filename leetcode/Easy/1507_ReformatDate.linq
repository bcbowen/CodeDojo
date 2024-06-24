<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests(); 
}

public string ReformatDate(string date)
{
	Dictionary<string, string> months = new Dictionary<string, string>(); 
	months.Add("Jan", "01");
	months.Add("Feb", "02");
	months.Add("Mar", "03");
	months.Add("Apr", "04");
	months.Add("May", "05");
	months.Add("Jun", "06");
	months.Add("Jul", "07");
	months.Add("Aug", "08");
	months.Add("Sep", "09");
	months.Add("Oct", "10");
	months.Add("Nov", "11");
	months.Add("Dec", "12");
	
	string pattern = @"(?<day>^\d+)[a-z]{2}\s(?<mon>[A-Z][a-z]{2})\s(?<year>[1,2]\d{3})$";
	System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(date, pattern); 
	
	return $"{match.Groups["year"]}-{months[match.Groups["mon"].Value]}-{match.Groups["day"].Value.PadLeft(2, '0')}"; 
}

/*
Example 1:
Input: date = "20th Oct 2052"
Output: "2052-10-20"

Example 2:
Input: date = "6th Jun 1933"
Output: "1933-06-06"

Example 3:
Input: date = "26th May 1960"
Output: "1960-05-26"
 
*/

[Theory]
[InlineData("20th Oct 2052", "2052-10-20")]
[InlineData("6th Jun 1933", "1933-06-06")]
[InlineData("26th May 1960", "1960-05-26")]
void Test(string date, string expected) 
{
	string result = ReformatDate(date);
	Assert.Equal(expected, result); 
}

