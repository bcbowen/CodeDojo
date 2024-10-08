<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Part1("input.txt");
	Part2("input.txt");
}


int Part1(string file)
{
	string path = Path.Combine(Utility.GetInputDirectory(), file);
	int result = 0;
	using (StreamReader reader = new StreamReader(path))
	{
		string line;
		while ((line = reader.ReadLine()) != null)
		{
			result += Calibrate(line);
		}
		reader.Close();
	}

	Console.WriteLine($"Part 1 result for {file}: {result}");
	return result;
}

int Part2(string file)
{
	string path = Path.Combine(Utility.GetInputDirectory(), file);
	int result = 0;
	using (StreamReader reader = new StreamReader(path))
	{
		string line;
		while ((line = reader.ReadLine()) != null)
		{
			result += Calibrate2(line);
		}
		reader.Close();
	}

	Console.WriteLine($"Part 2 result for {file}: {result}");
	return result;
}


private int Calibrate(string line)
{
	string s = "";
	foreach (char c in line)
	{
		if (char.IsDigit(c))
		{
			s += c;
			break;
		}
	}
	for (int i = line.Length - 1; i >= 0; i--)
	{
		if (char.IsDigit(line[i]))
		{
			s += line[i];
			break;
		}
	}
	return int.Parse(s);
}



private int Calibrate2(string line)
{
	string[] numbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

	string s = "";
	int minIndex = line.Length;
	string minDigit = "";
	for (int i = 0; i < numbers.Length; i++)
	{
		string number = numbers[i];
		int index = line.IndexOf(number);
		if (index > -1 && index < minIndex)
		{
			minIndex = index;
			minDigit = i.ToString();
		}
	}

	for (int i = 0; i < minIndex; i++)
	{
		if (char.IsDigit(line[i]))
		{
			minIndex = i;
			minDigit = line[i].ToString();
			break;
		}
	}
	s += minDigit;

	int maxIndex = 0;
	string maxDigit = "";
	for (int i = 0; i < numbers.Length; i++)
	{
		string number = numbers[i];
		int index = line.LastIndexOf(number);
		if (index > maxIndex)
		{
			maxIndex = index;
			maxDigit = i.ToString();
		}
	}

	for (int i = line.Length - 1; i >= maxIndex; i--)
	{
		if (char.IsDigit(line[i]))
		{
			maxIndex = i;
			maxDigit = line[i].ToString();
			break;
		}
	}

	s += maxDigit;
	int result;
	if (int.TryParse(s, out result))
	{
		//Console.WriteLine($"{line}: {result}");
		return result;
	}
	else
	{
		Console.WriteLine($"Problem with {line}: {s}");
		return 0;
	}
}

/*
1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet
In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 
142.
*/

[Fact]
void Part1Test()
{
	int expected = 142;
	int result = Part1("sample.txt");
	Assert.Equal(expected, result);
}

/*
two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen
In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.
*/
[Fact]
void Part2Test()
{
	int expected = 281;
	int result = Part2("sample2.txt");
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("two1nine", 29)]
[InlineData("eightwothree", 83)]
[InlineData("abcone2threexyz", 13)]
void Calibrate2Test(string line, int expected)
{
	int result = Calibrate2(line);
	Assert.Equal(expected, result);
}