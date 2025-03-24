<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

internal void ProcessValue(int value, StringBuilder output, string roman, ref int remainder) 
{
	if (remainder >= value) 
	{
		output.Append(roman); 
		remainder -= value;
	}
	
}

public string IntToRoman(int num)
{
	int remainder = num;
	StringBuilder result = new StringBuilder(); 
	while(remainder >= 1000) 
	{
		ProcessValue(1000, result, "M", ref remainder); 
	}

	ProcessValue(900, result, "CM", ref remainder); 
	ProcessValue(500, result, "D", ref remainder); 
	ProcessValue(400, result, "CD", ref remainder); 

	while (remainder >= 100) 
	{
		ProcessValue(100, result, "C", ref remainder);
	}

	ProcessValue(90, result, "XC", ref remainder); 
	ProcessValue(50, result, "L", ref remainder); 
	ProcessValue(40, result, "XL", ref remainder); 

	while (remainder >= 10) 
	{
		ProcessValue(10, result, "X", ref remainder);
	}
	
	ProcessValue(9, result, "IX", ref remainder); 
	ProcessValue(5, result, "V", ref remainder); 
	ProcessValue(4, result, "IV", ref remainder); 

	while(remainder >= 1) 
	{
		ProcessValue(1, result, "I", ref remainder); 
	}
	
	return result.ToString();
}



#region private::Tests

[Theory]
[InlineData(1, "I")]
[InlineData(3, "III")]
[InlineData(4, "IV")]
[InlineData(5, "V")]
[InlineData(6, "VI")]
[InlineData(8, "VIII")]
[InlineData(9, "IX")]
[InlineData(10, "X")]
[InlineData(11, "XI")]
[InlineData(13, "XIII")]
[InlineData(14, "XIV")]
[InlineData(15, "XV")]
[InlineData(18, "XVIII")]
[InlineData(19, "XIX")]
[InlineData(20, "XX")]
[InlineData(33, "XXXIII")]
[InlineData(35, "XXXV")]
[InlineData(40, "XL")]
[InlineData(58, "LVIII")]
[InlineData(100, "C")]
[InlineData(400, "CD")]
[InlineData(500, "D")]
[InlineData(600, "DC")]
[InlineData(1994, "MCMXCIV")]
[InlineData(2000, "MM")]
[InlineData(3999, "MMMCMXCIX")]
void Test(int num, string expected) 
{
	string result = IntToRoman(num);
	Assert.Equal(expected, result);
}

/*
Example 1:

Input: num = 3
Output: "III"
Explanation: 3 is represented as 3 ones.
Example 2:

Input: num = 58
Output: "LVIII"
Explanation: L = 50, V = 5, III = 3.
Example 3:

Input: num = 1994
Output: "MCMXCIV"
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
*/

#endregion