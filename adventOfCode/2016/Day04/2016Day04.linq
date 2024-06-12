<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests(); 
	List<RoomInfo> rooms = LoadRooms(); 
	int result = Part1(rooms);
	Console.WriteLine($"Part1: {result}");
	result = Part2(rooms); 
	Console.WriteLine($"Part2: {result}");
}


class RoomInfo
{
	public int SectionId { get; set; }
	public string Hash { get; set; }
	public string CalculatedHash {get; set; }
	public string[] EncryptedWords { get; set; }
	public string[] DecryptedWords { get; set; }
	public bool IsValid { get { return Hash == CalculatedHash; }}

	private RoomInfo()
	{} 

	public static RoomInfo Parse(string line)
	{
		Dictionary<char, int> charCounts = new Dictionary<char, int>();
		string[] fields = line.Split('-');
		RoomInfo room = new RoomInfo(); 
		room.EncryptedWords = new string[fields.Length - 1]; 
		for (int i = 0; i < fields.Length - 1; i++)
		{
			room.EncryptedWords[i] = fields[i]; 
			foreach (char c in fields[i])
			{
				if (!charCounts.ContainsKey(c)) charCounts.Add(c, 0);
				charCounts[c]++;
			}
		}
		string pattern = @"\d*";
		Match match = Regex.Match(fields[^1], pattern);
		room.SectionId = int.Parse(match.Value); // int.Parse(match.Groups[1].Value);

		pattern = @"\[([a-z]+)\]";
		match = Regex.Match(fields[^1], pattern);
		room.Hash = match.Groups[1].Value;

		//StringBuilder hashBuilder = new StringBuilder(); 
		var sortedKeys = charCounts.OrderByDescending(pair => pair.Value)
			.ThenBy(pair => pair.Key)
			.Select(pair => pair.Key)
			.Take(5);


		room.CalculatedHash = string.Join("", sortedKeys);

		// decrypt 
		if (room.IsValid) 
		{
			room.DecryptedWords = new string[room.EncryptedWords.Length]; 
			int offset = room.SectionId % 26;
			for(int i = 0; i < room.EncryptedWords.Length; i++)
			{
				string word = room.EncryptedWords[i]; 
				room.DecryptedWords[i] = DecryptWord(word, offset); 
			}
		}

		return room;
	}


	internal static string DecryptWord(string word, int offset)
	{
		StringBuilder result = new StringBuilder();
		foreach (char c in word)
		{
			int newAsc = (int)c + offset;
			if (newAsc > 'z') newAsc = 'a' + newAsc - 'z' - 1;
			result.Append((char)newAsc);
		}

		return result.ToString();
	}
	
}

List<RoomInfo> LoadRooms() 
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string[] lines = File.ReadAllLines(path);

	List<RoomInfo> rooms = new List<RoomInfo>(); 
	
	foreach(string line in lines) 
	{
		rooms.Add(RoomInfo.Parse(line)); 
	}
	return rooms; 
	
}

int Part1(List<RoomInfo> rooms)
{
	return rooms.Where(r => r.IsValid).Sum(r => r.SectionId);
}

int Part2(List<RoomInfo> rooms) 
{
	RoomInfo room = rooms.FirstOrDefault(r => r.IsValid && string.Join(" ", r.DecryptedWords) == "northpole object storage"); 
	return room != null ? room.SectionId : -1; 
}


/*
aaaaa-bbb-z-y-x-123[abxyz] is a real room because the most common letters are a (5), b (3), and then a tie between x, y, and z, which are listed alphabetically.
a-b-c-d-e-f-g-h-987[abcde] is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
not-a-real-room-404[oarel] is a real room.
totally-real-room-200[decoy] is not.
*/

[Theory]
[InlineData("aaaaa-bbb-z-y-x-123[abxyz]", true)]
[InlineData("a-b-c-d-e-f-g-h-987[abcde]", true)]
[InlineData("not-a-real-room-404[oarel]", true)]
[InlineData("totally-real-room-200[decoy]", false)]
void TestIsRealRoom(string code, bool expected) 
{
	//int result = ParseSectorId(code); 
	RoomInfo room = RoomInfo.Parse(code); 
	Assert.Equal(expected, room.IsValid); 
}

/*
[Theory]
[InlineData("qzmt-zixmtkozy-ivhz-343", "very encrypted name")]
void DecryptTest(string line, string expected)
{
	string result = Decrypt(line); 
	Assert.Equal(expected, result); 
}
*/

[Theory]
[InlineData("ana", 1, "bob")]
void DecryptWordTest(string word, int offset, string expected) 
{
	string result = RoomInfo.DecryptWord(word, offset); 
	Assert.Equal(expected, result); 
}