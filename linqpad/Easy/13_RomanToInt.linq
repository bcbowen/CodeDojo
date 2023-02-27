<Query Kind="Program" />

void Main()
{
	
}

public class Solution
{
	public int RomanToInt(string s)
	{
		int sum = 0;
		for (int i = 0; i < s.Length; i++)
		{
			(int value, bool skip) = RomanNumeral.CalcValue(s[i], i < s.Length - 1 ? s[i + 1] : '_');
			sum += value;
			if (skip)
			{
				i++;
			}
		}
		return sum;
	}


}

internal class RomanNumeral
{
	public RomanNumeral(char character)
	{
		Character = character;
	}

	public char Character { get; init; }
	public int Value
	{
		get
		{
			switch (Character)
			{
				case 'I':
					return 1;
				case 'V':
					return 5;
				case 'X':
					return 10;
				case 'L':
					return 50;
				case 'C':
					return 100;
				case 'D':
					return 500;
				case 'M':
					return 1000;
				default:
					return 0;
			}

		}
	}

	public static (int, bool) CalcValue(char current, char next)
	{
		bool isCombo = false;
		int value;

		RomanNumeral currentNumeral = new RomanNumeral(current);
		RomanNumeral nextNumeral = new RomanNumeral(next);
		int currentVal = currentNumeral.Value;
		int nextVal = nextNumeral.Value;
		if (nextVal > currentVal)
		{
			value = nextVal - currentVal;
			isCombo = true;
		}
		else
		{
			value = currentVal;
		}
		return (value, isCombo);
	}

}