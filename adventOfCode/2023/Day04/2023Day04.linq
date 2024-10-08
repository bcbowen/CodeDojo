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

class ScratchCard
{
	public int Copies { get; set; }
	public List<int> WinningNumbers { get; private set; } = new List<int>();
	public List<int> PlayedNumbers { get; private set; } = new List<int>();
	public List<int> GetWinners()
	{
		return WinningNumbers.Intersect(PlayedNumbers).ToList();
	}
	public int Part1Score()
	{
		List<int> winners = GetWinners();
		if (winners.Count == 0) return 0;

		return (int)Math.Pow(2, winners.Count - 1);
	}

	public static ScratchCard Parse(string line)
	{
		ScratchCard card = new ScratchCard();
		string valueString = line.Substring(line.IndexOf(':') + 1);
		//List<int> cardNumbers = new List<int>(); 
		//List<int> myNumbers = new List<int>(); 
		string[] groups = valueString.Split('|');
		// card numbers
		string[] values = groups[0].Split(' ');
		int test;
		foreach (string value in values)
		{
			if (int.TryParse(value, out test))
			{
				card.WinningNumbers.Add(test);
			}
		}

		// my numbers
		values = groups[1].Split(' ');
		foreach (string value in values)
		{
			if (int.TryParse(value, out test))
			{
				card.PlayedNumbers.Add(test);
			}
		}
		card.Copies = 1;
		return card;
	}

	public static List<ScratchCard> Load(string fileName)
	{
		List<ScratchCard> cards = new List<ScratchCard>();

		string path = Path.Combine(Utility.GetInputDirectory(), fileName);

		string[] lines = File.ReadAllLines(path);
		foreach (string line in lines)
		{
			cards.Add(ScratchCard.Parse(line));
		}

		return cards;
	}
}

int Part1(string fileName)
{
	int total = 0;
	List<ScratchCard> cards = ScratchCard.Load(fileName);
	foreach (ScratchCard card in cards)
	{
		total += card.Part1Score();
	}
	Console.WriteLine($"Part1 total: {total}");
	return total;
}

int Part2(string fileName)
{
	List<ScratchCard> cards = ScratchCard.Load(fileName);
	for (int i = 0; i < cards.Count; i++)
	{
		ScratchCard card = cards[i];
		List<int> matches = card.GetWinners();
		for (int j = i + 1; j < i + matches.Count + 1; j++)
		{
			cards[j].Copies += card.Copies;
		}
	}
	int result = cards.Sum(c => c.Copies);
	Console.WriteLine($"Part 2 card count: {result}");
	return result;

}

[Fact]
void ParseLineTest()
{
	string line = "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1";
	ScratchCard card = ScratchCard.Parse(line);
	Assert.Equal(new int[] { 1, 21, 53, 59, 44 }, card.WinningNumbers.ToArray());
	Assert.Equal(new int[] { 69, 82, 63, 72, 16, 21, 14, 1 }, card.PlayedNumbers.ToArray());
}

[Fact]
void Part1Test()
{
	int expected = 13;
	int result = Part1("sample.txt");
	Assert.Equal(expected, result);
}

[Fact]
void Part2Test()
{
	int expected = 30;
	int result = Part2("sample.txt");
	Assert.Equal(expected, result);
}