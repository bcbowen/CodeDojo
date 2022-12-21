<Query Kind="Program">
  <Namespace>Xunit</Namespace>
  <Namespace>System.Numerics</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public string Multiply(string x, string y)
	{
		if (x == "0" || y == "0") return "0"; 
		if (x == "1") return y; 
		if (y == "1") return x; 
		if (x.Length <= 6 && y.Length < 6)
		{
			if (x.Length == 1 || y.Length == 1) return (int.Parse(x) * int.Parse(y)).ToString();
		}


		(x, y) = SetSizes(x, y);
		int xLen = x.Length;
		int yLen = y.Length;
		int n = System.Math.Min(xLen, yLen);
		x = x.PadLeft(n, '0');
		y = y.PadLeft(n, '0');
		int halfN = (int)(System.Math.Ceiling((double)n / 2));
		string a, b, c, d;
		(a, b) = SplitValue(x, halfN);

		(c, d) = SplitValue(y, halfN);

		string step1 = Multiply(a, c);
		string step2 = Multiply(b, d);
		string step3a = Multiply(Add(a, b), Add(c, d));
		string step3b = Subtract(step3a, step1);
		string step3 = Subtract(step3b, step2);
		// subtract step 2 from step 3

		string resulta = step1.PadRight(step1.Length + n, '0');
		string resultb = step3.PadRight(step3.Length + halfN, '0');
		string result = Add(Add(resulta, resultb), step2);

		//value = Subtract(value, step1.PadRight(step1.Length + x.Length / 2, '0'));

		return result;
	}

	private static (string, string) SplitValue(string value, int n)
	{
		string y = value.Substring(value.Length - n);
		string x = value.Substring(0, value.Length - n);

		string pattern = "^0+$";
		x = Regex.IsMatch(x, pattern) ? "0" : x.TrimStart('0');

		return (x, y);
	}

	internal static string Subtract2(string x, string y)
	{
		BigInteger i = BigInteger.Parse(x);
		BigInteger j = BigInteger.Parse(y);
		return BigInteger.Subtract(i, j).ToString();
	}

	internal static string Subtract(string x, string y)
	{
		if (x == y) return "0";
		bool borrow = false;
		StringBuilder result = new StringBuilder();

		if (y.Length < x.Length) y = y.PadLeft(x.Length, '0');

		int top;
		int bottom;
		int difference;
		for (int i = x.Length - 1; i >= 0; i--)
		{
			top = int.Parse(x.Substring(i, 1));
			bottom = int.Parse(y.Substring(i, 1));
			if (borrow)
			{
				if (top == 0)
				{ 
					top = 9; 
				}
				else
				{
					top--;
					borrow = false;
				}
			}
			
			if (top < bottom)
			{
				borrow = true;
				top += 10;
			}
			
			difference = top - bottom;
			result.Insert(0, difference);

		}

		return result.ToString().TrimStart('0');

	}

	internal static string Add2(string x, string y)
	{
		BigInteger i = BigInteger.Parse(x);
		BigInteger j = BigInteger.Parse(y);
		return BigInteger.Add(i, j).ToString();
	}

	internal static string Add(string x, string y)
	{
		int carry = 0;
		int top;
		int bottom;
		int sum;
		int n = Math.Max(x.Length, y.Length);
		x = x.PadLeft(n, '0');
		y = y.PadLeft(n, '0');
		if (x.Length == 1 || y.Length == 1)
		{
			return (int.Parse(x) + int.Parse(y)).ToString();
		}
		StringBuilder result = new StringBuilder();
		for (int i = x.Length - 1; i >= 0; i--)
		{
			top = int.Parse(x.Substring(i, 1));
			bottom = int.Parse(y.Substring(i, 1));
			sum = top + bottom + carry;
			if (sum > 9)
			{
				carry = 1;
				result.Insert(0, sum - 10);
			}
			else
			{
				carry = 0;
				result.Insert(0, sum);
			}
		}
		if (carry == 1)
		{
			result.Insert(0, carry);
		}

		return result.ToString().TrimStart('0');
	}

	internal static (string, string) SetSizes(string x, string y)
	{
		x = SetSize(x);
		y = SetSize(y);

		if (x.Length > y.Length)
		{
			y = y.PadLeft(x.Length, '0');
		}
		else if (y.Length > x.Length)
		{
			x = x.PadLeft(y.Length, '0');
		}

		return (x, y);
	}

	internal static string SetSize(string value)
	{
		int len = GetIdealSize(value);
		if (value.Length == len)
		{
			return value;
		}

		return value.PadLeft(len, '0');
	}

	internal static int GetIdealSize(string value)
	{
		if (string.IsNullOrEmpty(value)) return 0;

		// if length is 1 or 2, leave it as it is
		if (value.Length < 3) return value.Length;

		// if the length is already a power of 2 it is good
		if (System.Math.Log2(value.Length) % 1 == 0) return value.Length;

		int testLen = 2;
		while (testLen < value.Length)
		{
			testLen *= 2;
		}

		return testLen;
	}
}

#region private::Tests

[Theory]
[InlineData("0", "332620029", "0")]
[InlineData("9133", "0", "0")]
[InlineData("2", "3", "6")]
[InlineData("2", "4", "8")]
[InlineData("1", "2", "2")]
[InlineData("6", "3", "18")]
[InlineData("5", "6", "30")]
[InlineData("8", "5", "40")]
[InlineData("20", "4", "80")]
[InlineData("37", "32", "1184")]
[InlineData("81", "89", "7209")]
[InlineData("20", "40", "800")]
[InlineData("134", "46", "6164")]
[InlineData("5678", "1234", "7006652")]
[InlineData("51", "46", "2346")]
[InlineData("51", "42", "2142")]
[InlineData("93", "76", "7068")]
[InlineData("26", "71", "1846")]
[InlineData("6937", "2423", "16808351")]
[InlineData("5176", "4440", "22981440")]
[InlineData("1385", "3751", "5195135")] // sub
[InlineData("127", "102", "12954")]
[InlineData("5077", "8319", "42235563")]
[InlineData("5127", "4265", "21866655")] // sub
[InlineData("123", "456", "56088")]
void SmallTests(string x, string y, string expected)
{
	string result = new Solution().Multiply(x, y);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("9", "1", "8")]
[InlineData("134", "123", "11")]
[InlineData("533", "77", "456")]
[InlineData("0", "0", "0")]
[InlineData("9", "0", "9")]
[InlineData("6164", "4600", "1564")]
[InlineData("105", "56", "49")]
[InlineData("1000", "1", "999")]
[InlineData("234", "189", "45")]
[InlineData("56238", "19758", "36480")]
//[InlineData("", "", "")]
public void SubtractTests(string x, string y, string expected)
{
	string result = Solution.Subtract(x, y);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("1385", "3751", "5195135")] // sub
[InlineData("5127", "4265", "21866655")] // sub
void SmallTestsDebug(string x, string y, string expected)
{
	string result = new Solution().Multiply(x, y);
	Assert.Equal(expected, result);
}
/*

Example 1:
Input: num1 = "2", num2 = "3"
Output: "6"

Example 2:
Input: num1 = "123", num2 = "456"
Output: "56088"

*/
[Theory]
[InlineData("1", 1)]
[InlineData("10", 2)]
[InlineData("103", 4)]
[InlineData("1234", 4)]
[InlineData("123456", 8)]
[InlineData("12345678", 8)]
[InlineData("1234567890", 16)]
public void GetIdealSizeTests(string value, int expectedSize)
{
	int result = Solution.GetIdealSize(value);
	Assert.Equal(expectedSize, result);
}

[Theory]
[InlineData("1", "1")]
[InlineData("10", "10")]
[InlineData("103", "0103")]
[InlineData("1234", "1234")]
[InlineData("123456", "00123456")]
[InlineData("12345678", "12345678")]
[InlineData("1234567890", "0000001234567890")]
public void SetSizeTests(string value, string expected)
{
	string result = Solution.SetSize(value);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("1", "2", "1", "2")]
[InlineData("13", "2", "13", "02")]
[InlineData("1", "10", "01", "10")]
[InlineData("103", "0103", "0103", "0103")]
[InlineData("1", "1234", "0001", "1234")]
public void TestSetSizes(string x, string y, string expectedX, string expectedY)
{
	(string resultX, string resultY) = Solution.SetSizes(x, y);
	Assert.Equal(expectedX, resultX);
	Assert.Equal(expectedY, resultY);

}

#endregion