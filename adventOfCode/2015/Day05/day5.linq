<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	List<string> words = new List<string>();
	using (StreamReader reader = new StreamReader(path))
	{
		string line;
		while ((line = reader.ReadLine()) != null)
		{
			words.Add(line);
		}
		reader.Close();
	}
	string input = File.ReadAllText(path);
	Part1(words);
	Part2(words); 
	// following 2 are for troubleshooting part 2
	GetNiceStringCountAfterSantaHadRevisedHisClearlyRidiculousRulesBecauseNewRulesRockAndWeShouldAlwaysTotallyBeMovingForward(words); 
	GetCounts(words); 
	CompareMethods(words); 
}

static bool IsNice(string value) 
{
	int vowelCount = 0;
	bool hasDoubleLetter = false;
	char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
	string[] poisonStrings = {"ab", "cd", "pq", "xy"};
	char previous = value[0];
	if (vowels.Contains(previous)) vowelCount++; 
	for (int i = 1; i < value.Length; i++)
	{
		if (poisonStrings.Contains(new string(new char[] {previous, value[i]}))) return false;
		if (vowels.Contains(value[i])) vowelCount++; 
		if (previous == value[i]) hasDoubleLetter = true; 
		previous = value[i]; 
	}
	
	return vowelCount > 2 && hasDoubleLetter;
}


static Nice2Result IsNice2(string word)
{

	Nice2Result result = Nice2Result.IsShit; 
	// pair check 
	for (int i = 1; i < word.Length; i++) 
	{
		string pair = word.Substring(i - 1, 2);
		string remaining = word.Substring(i + 1);
		if (remaining.Contains(pair)) 
		{
			result |= Nice2Result.HasPair;
			break;
		}
	}

	// divided pair check
	for(int i = 2; i < word.Length; i++)
	{
		// Note Original implementation: the directions seem to me to say a divided pair has a different character in the middle but the "accepted" solution does not do this
		/* 
		if (word[i - 2] == word[i] && word[i - 1] != word[i]) 
		{
			result |= Nice2Result.HasDividedPair; 
			break;
		}
		*/
		// fixed based on accepted solution: 
		if (word[i - 2] == word[i])
		{
			result |= Nice2Result.HasDividedPair;
			break;
		}
	}

	return result; 
	
}

enum Nice2Result 
{
	IsShit = 0,
	HasPair = 1, 
	HasDividedPair = 2, 
	IsNice = 3
	
}

static void Part1(List<string> words) 
{
	int niceCount = 0;
	foreach (string word in words)
	{
		if (IsNice(word)) niceCount++; 
	}

	Console.WriteLine($"Part1: {niceCount}"); 
}

static void Part2(List<string> words)
{
	int shitCount = 0; 
	int pairOnly = 0;
	int dividedPairOnly = 0; 
	int niceCount = 0;
	foreach (string word in words)
	{
		Nice2Result result = IsNice2(word);
		switch(result) 
		{
			case Nice2Result.IsShit: 
				shitCount++; 
				break; 
			case Nice2Result.HasPair: 
				pairOnly++; 
				break; 
			case Nice2Result.HasDividedPair: 
				dividedPairOnly++; 
				break;
			default: 
				niceCount++; 
				break;
		}
	}

	Console.WriteLine($"Part2: Shit: {shitCount}; PairOnly: {pairOnly}; DividedPairOnly: {dividedPairOnly}; Nice:{niceCount}");
}

// The following 4 methods are someone else's solution, using it to troubleshoot my problem with part 2... the answer is 69 and I get 67
public static void
		GetNiceStringCountAfterSantaHadRevisedHisClearlyRidiculousRulesBecauseNewRulesRockAndWeShouldAlwaysTotallyBeMovingForward
		(List<string> words)
{
	// God damn it, santa.
	var ret = words.Where(s => HasPair(s) && HasRepeats(s)).ToList();

	Console.WriteLine($"Solution result: {ret.Count}");
}

public static void GetCounts (List<string> words)
{
	Nice2Result result;
	int shitCount = 0;
	int pairOnly = 0;
	int dividedPairOnly = 0;
	int niceCount = 0;

	foreach (string word in words) 
	{
		result = Nice2Result.IsShit;
		if (HasPair(word)) result |= Nice2Result.HasPair; 
		if (HasRepeats(word)) result |= Nice2Result.HasDividedPair;

		switch (result)
		{
			case Nice2Result.IsShit:
				shitCount++;
				break;
			case Nice2Result.HasPair:
				pairOnly++;
				break;
			case Nice2Result.HasDividedPair:
				dividedPairOnly++;
				break;
			default:
				niceCount++;
				break;
		}
	}


	Console.WriteLine($"Troubleshooting count: Shit: {shitCount}; PairOnly: {pairOnly}; DividedPairOnly: {dividedPairOnly}; Nice:{niceCount}");
}

private static bool HasPair(string s)
{
	for (int i = 0; i < s.Length - 1; i++)
	{
		string pair = s.Substring(i, 2);
		if (s.IndexOf(pair, i + 2) != -1)
			return true;
	}

	return false;
}

private static bool HasRepeats(string s)
{
	for (int i = 0; i < s.Length - 2; i++)
	{
		if (s[i] == s[i + 2])
			return true;
	}

	return false;
}

private static Nice2Result OtherMethod(string word) 
{
	Nice2Result result = Nice2Result.IsShit;
	if (HasPair(word)) result |= Nice2Result.HasPair;
	if (HasRepeats(word)) result |= Nice2Result.HasDividedPair;
	return result;

}

private static void CompareMethods(List<string> words) 
{
	Nice2Result myResult; 
	Nice2Result otherResult;

	foreach(string word in words) 
	{
		myResult = IsNice2(word);
		otherResult = OtherMethod(word);
		if (myResult != otherResult)
		{
			Console.WriteLine($"Word: {word}; I say {myResult}, he says {otherResult} "); 
		}
	}
}

[Theory]
[InlineData("ugknbfddgicrmopn", true)]
[InlineData("aaa", true)]
[InlineData("jchzalrnumimnmhp", false)]
[InlineData("haegwjzuvuyypxyu", false)]
[InlineData("dvszwmarrgswjxmb", false)]
void IsNiceTest(string value, bool expected)
{
	bool result = IsNice(value); 
	Assert.Equal(expected, result); 
}



[Theory]
[InlineData("qjhvhtzxzqqjkmpb", Nice2Result.IsNice)]
[InlineData("xxyxx", Nice2Result.IsNice)]
[InlineData("uurcxstgmygtbstg", Nice2Result.HasPair)]
[InlineData("ieodomkazucvgmuy", Nice2Result.HasDividedPair)]
[InlineData("xxabcxxdefghijkj", Nice2Result.IsNice)]
[InlineData("jkjxxabcxxdefghi", Nice2Result.IsNice)]
[InlineData("xxabcxxdjkjefghi", Nice2Result.IsNice)]
[InlineData("abcxxdjkjefxxghi", Nice2Result.IsNice)]
[InlineData("abcxxdjkjefghixx", Nice2Result.IsNice)]
[InlineData("abcdjkjefxxxghi", Nice2Result.HasDividedPair)]
[InlineData("abcdjkjefxxxxghi", Nice2Result.IsNice)]
[InlineData("xxxx", Nice2Result.HasPair)]
[InlineData("xxx", Nice2Result.IsShit)]
[InlineData("xxxxyx", Nice2Result.IsNice)]
void IsNice2Test(string value, Nice2Result expected)
{
	Nice2Result result = IsNice2(value);
	Assert.Equal(expected, result);
}