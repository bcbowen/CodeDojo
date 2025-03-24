<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int MyAtoi(string s)
{
	long value = 0;
	bool isValid = IsValid(s);
	if (isValid)
	{
		bool isNegative = IsNegative(s);
		string stringValue = ParseValue(s);
		long multiplier = 1;
		if (stringValue.Length <= 10)
		{
			for (int i = stringValue.Length - 1; i >= 0; i--)
			{
				int digit = stringValue[i] - '0';
				value += digit * multiplier;
				multiplier *= 10;
			}
			if (isNegative)
			{
				value *= -1;
				value = Math.Max(value, int.MinValue);
			}
			else
			{
				value = Math.Min(value, int.MaxValue);
			}
		}
		else
		{
			value = isNegative ? int.MinValue : int.MaxValue;
		}
	}
	else
	{
		value = 0;
	}


	return (int)value;	
}

internal bool IsValid(string s) 
{
	int pos = 0; 
	int firstDigit = -1; 
	int firstSignificantDigit = -1; 
	int signCount = 0; 
	int signLocation = -1;
	int lastDigit = -1;
	bool isValid = true;
	char[] signs = {'+', '-'}; 

	while (pos < s.Length)
	{
		if (signs.Contains(s[pos]) && firstDigit == -1)
		{
			signCount++;
			signLocation = pos;
			if (firstDigit > -1 || signCount > 1) 
			{
				isValid = false; 
				break;
			}
			
		}
		else if(char.IsDigit(s[pos])) 
		{
			if (firstDigit == -1) firstDigit = pos; 
			lastDigit = pos;
		}
		else if (s[pos] == ' ' && signLocation != -1) 
		{
			// once we've reached the sign, the only valid characters are digits. 
			// if we haven't found a digit yet, it's not a valid number
			isValid = firstDigit > -1; 
			break;
		}
		else if (s[pos] != ' ' && firstDigit == -1) 
		{
			isValid = false;
			break;
		}
		else if (lastDigit > -1)
		{
			break;
		}
		pos++; 
	}
	
	return isValid;
}

internal bool IsNegative(string s) 
{
	int pos = 0;
	bool isNegative = false;
	
	while (pos < s.Length)
	{
		if (s[pos] == '-')
		{
			isNegative = true;
		}	
		else if (char.IsDigit(s[pos]))
		{
			break;
		}
		pos++;
	}

	return isNegative; 

}

internal string ParseValue(string s)
{
	int begin = -1;
	int firstSignificantDigit = -1; 
	int end = 0;
	int pos = 0;
	while (pos < s.Length && begin == -1)
	{
		if (char.IsDigit(s[pos]))
		{
			begin = pos;
			if (s[pos] > '0') firstSignificantDigit = pos;
			end = pos; 
			break;
		}
		else if (!new[] {' ', '-', '+', '0'}.Contains(s[pos])) 
		{
			break;
		}
		pos++;
	}

	if (begin > -1) 
	{
		while (pos < s.Length && char.IsDigit(s[pos]))
		{
			if (firstSignificantDigit == -1 && s[pos] > '0') firstSignificantDigit = pos;
			pos++;
			end++;
		}
	}
	
	string stringValue = firstSignificantDigit == -1 ? "0" : s.Substring(firstSignificantDigit, end - firstSignificantDigit);
	return stringValue;

}

#region private::Tests

/*

Example 1:

Input: s = "42"
Output: 42
Explanation: The underlined characters are what is read in, the caret is the current reader position.
Step 1: "42" (no characters read because there is no leading whitespace)
         ^
Step 2: "42" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "42" ("42" is read in)
           ^
The parsed integer is 42.
Since 42 is in the range [-2^31, 2^31 - 1], the final result is 42.
Example 2:

Input: s = "   -42"
Output: -42
Explanation:
Step 1: "   -42" (leading whitespace is read and ignored)
            ^
Step 2: "   -42" ('-' is read, so the result should be negative)
             ^
Step 3: "   -42" ("42" is read in)
               ^
The parsed integer is -42.
Since -42 is in the range [-2^31, 2^31 - 1], the final result is -42.
Example 3:

Input: s = "4193 with words"
Output: 4193
Explanation:
Step 1: "4193 with words" (no characters read because there is no leading whitespace)
         ^
Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
             ^
The parsed integer is 4193.
Since 4193 is in the range [-2^31, 2^31 - 1], the final result is 4193.

*/

[Theory]
[InlineData("42", false)]
[InlineData("0", false)]
[InlineData("-42", true)]
[InlineData("    42", false)]
[InlineData("    0", false)]
[InlineData("  -42", true)]
[InlineData("42 dude", false)]
[InlineData("0 man", false)]
[InlineData("-42  ", true)]
[InlineData("2147483647", false)]
[InlineData("3147483647", false)] // > int.max
[InlineData("-2147483648", true)]
[InlineData("-3147483648", true)] // < int.min
[InlineData("dude", false)]
[InlineData("+42", false)]
[InlineData("   +42  cheesypoofs", false)]
void IsNegativeTest(string value, bool expected)
{
	bool result = IsNegative(value);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("+-12", false)]
[InlineData("+12", true)]
[InlineData("-12", true)]
[InlineData("--12", false)]
[InlineData("12", true)]
[InlineData("00000-42a1234", true)]
[InlineData("   +42  cheesypoofs", true)]
[InlineData("   +0 123", true)]
[InlineData("-5-", true)]
[InlineData("  +  413", false)]
void IsValidTest(string value, bool expected)
{
	bool result = IsValid(value);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("42", "42")]
[InlineData("0", "0")]
[InlineData("-42", "42")]
[InlineData("    42", "42")]
[InlineData("    0", "0")]
[InlineData("  -42", "42")]
[InlineData("42 dude", "42")]
[InlineData("0 man", "0")]
[InlineData("-42  ", "42")]
[InlineData("2147483647", "2147483647")]
[InlineData("3147483647", "3147483647")] // > int.max
[InlineData("-2147483648", "2147483648")]
[InlineData("-3147483648", "3147483648")] // < int.min
[InlineData("dude", "0")]
[InlineData("+42", "42")]
[InlineData("   +42  cheesypoofs", "42")]
[InlineData("   words and 987", "0")]
[InlineData("  0000000000012345678", "12345678")]
[InlineData("   +0 123", "0")]
void ParseValueTest(string value, string expected)
{
	string result = ParseValue(value);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("42", 42)]
[InlineData("0", 0)]
[InlineData("-42", -42)]
[InlineData("    42", 42)]
[InlineData("    0", 0)]
[InlineData("  -42", -42)]
[InlineData("42 dude", 42)]
[InlineData("0 man", 0)]
[InlineData("-42  ", -42)]
[InlineData("dude", 0)]
[InlineData("+42", 42)]
[InlineData("   +42  cheesypoofs", 42)]
[InlineData("   words and 987", 0)]
[InlineData("+-12", 0)]
[InlineData("9223372036854775808", 2147483647)]
[InlineData("00000-42a1234", 0)]
[InlineData("   +0 123", 0)]
void Test(string value, int expected)
{
	int result = MyAtoi(value); 
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("2147483647", 2147483647)]
[InlineData("3147483647", 2147483647)] // > int.max
[InlineData("-2147483648", -2147483648)]
[InlineData("-3147483648", -2147483648)] // < int.min
void BigValuesTest(string value, int expected)
{
	int result = MyAtoi(value);
	Assert.Equal(expected, result);
}


#endregion