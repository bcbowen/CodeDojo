<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public bool IsNumber(string s)
{
	bool hasSign = false; 
	bool hasDecimal = false; 
	bool hasE = false;
	bool hasDigit = false; 

	char[] ees = { 'e', 'E' };
	char[] signs = {'-', '+'};
	
	if (string.IsNullOrEmpty(s)) return false; 
	if (s.Length == 1) return char.IsDigit(s[0]);

	int i = 0;
	while (i < s.Length) 
	{
		char c = s[i];
		if (signs.Contains(c)) 
		{
			bool afterE = i > 0 && ees.Contains(s[i - 1]);
			// sign only valid before any digits or immediately after e
			if ((hasDigit || hasDecimal || hasSign) && !afterE) return false;
			// sign after e must be followed by digit
			if (afterE && i == s.Length - 1) return false;
			if (!afterE) hasSign = true;
		}
		else if (ees.Contains(c))
		{
			// can only have 1 e; e must come after a digit; e must be followed by a digit or a sign
			if (hasE || !hasDigit || i == s.Length - 1) return false; 
			hasE = true;
		}
		else if (c == '.') 
		{
			// only ints can follow E
			if (hasDecimal || hasE) return false; 
			// decimal must be preceeded or followed by digits
			if (!hasDigit && i == s.Length - 1) return false;
			hasDecimal = true;
		}
		else if (char.IsDigit(c)) 
		{
			hasDigit = true;
		}
		else 
		{
			return false;
		}
				
		i++; 
	}
	
	return true; 
}

#region private::Tests

/*
A decimal number or an integer.
(Optional) An 'e' or 'E', followed by an integer.

A decimal number can be split up into these components (in order):

(Optional) A sign character (either '+' or '-').
One of the following formats:
One or more digits, followed by a dot '.'.
One or more digits, followed by a dot '.', followed by one or more digits.
A dot '.', followed by one or more digits.
An integer can be split up into these components (in order):

(Optional) A sign character (either '+' or '-').
One or more digits.


Example 1:

Input: s = "0"
Output: true
Example 2:

Input: s = "e"
Output: false
Example 3:

Input: s = "."
Output: false

*/

[Theory]
[InlineData("+", false)]
[InlineData("4e+", false)]
[InlineData("2", true)]
[InlineData("e", false)]
[InlineData(".", false)]
[InlineData("2", true)]
[InlineData("0089", true)]
[InlineData("-0.1", true)]
[InlineData("+3.14", true)]
[InlineData("4.", true)]
[InlineData("-.9", true)]
[InlineData("2e10", true)]
[InlineData("-90E3", true)]
[InlineData("3e+7", true)]
[InlineData("+6e-1", true)]
[InlineData("53.5e93", true)]
[InlineData("-123.456e789", true)]
[InlineData("abc", false)]
[InlineData("1a", false)]
[InlineData("1e", false)]
[InlineData("e3", false)]
[InlineData("99e2.5", false)]
[InlineData("--6", false)]
[InlineData("-+3", false)]
[InlineData("95a54e53", false)]
void Test(string value, bool expected) 
{
	bool result = IsNumber(value);
	Assert.Equal(expected, result);	
}


#endregion