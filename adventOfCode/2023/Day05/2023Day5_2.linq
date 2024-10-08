<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	/* 
	Actual data has 2.2 billion seeds and takes 42 minutes. This can be optimized sometime by incrementing by 1000 
	after each calculation and seeing if the seed number matches the calculated seed number, 
	if so those 1000 calcs were skipped, otherwise the 1000 rows need to be run manually. This saves millions of calculations 
	because of the huge ranges in the seeds
	
	Fun facts: 
	seed			count			end seed
	768,975			36,881,621		37,650,596
	56,868,281		55,386,784		112,255,065
	357,791,695		129,980,646		487,772,341
	819,363,529		9,145,257		828,508,786
	993,170,544		70,644,734		1,063,815,278
	1,117,192,172	332,560,644		1,449,752,816
	1,828,225,758	1,084,205,557	2,912,431,315
	2,956,956,868	127,170,752		3,084,127,620
	3,107,544,690	59,359,615		3,166,904,305
	3,213,715,789	312,116,873		3,525,832,662
			
			
total count: 	2,217,452,483		

	
	*/
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Part2("input.txt");
}

long Part2(string fileName)
{
	NodeMap map = NodeMap.Load(fileName);
	long minLocationId = SeedLocation.GetMinSeedLocation(map);
	Console.WriteLine($"Part2 Result: {minLocationId}");
	return minLocationId;
}

class SeedLocation
{
	public long SeedId { get; set; }
	public long SoilId { get; set; }
	public long FertilizerId { get; set; }
	public long WaterId { get; set; }
	public long LightId { get; set; }
	public long TemperatureId { get; set; }
	public long HumidityId { get; set; }
	public long LocationId { get; set; }

	public static long GetMinSeedLocation(NodeMap map)
	{
		long minLocation = long.MaxValue;
		List<SeedLocation> result = new List<SeedLocation>();

		foreach ((long seed, long count) in map.Seeds)
		{
			for (long l = seed; l <= seed + count; l++)
			{
				SeedLocation location = new SeedLocation { SeedId = l };
				// soil
				NodeList currentNodeList = map.Map[0];
				location.SoilId = FindIdInMap(currentNodeList, l);
				currentNodeList = map.Map[1];
				location.FertilizerId = FindIdInMap(currentNodeList, location.SoilId);
				currentNodeList = map.Map[2];
				location.WaterId = FindIdInMap(currentNodeList, location.FertilizerId);
				currentNodeList = map.Map[3];
				location.LightId = FindIdInMap(currentNodeList, location.WaterId);
				currentNodeList = map.Map[4];
				location.TemperatureId = FindIdInMap(currentNodeList, location.LightId);
				currentNodeList = map.Map[5];
				location.HumidityId = FindIdInMap(currentNodeList, location.TemperatureId);
				currentNodeList = map.Map[6];
				location.LocationId = FindIdInMap(currentNodeList, location.HumidityId);
				minLocation = Math.Min(minLocation, location.LocationId);
			}

		}

		return minLocation;
	}

	internal static long FindIdInMap(NodeList nodeList, long id)
	{
		Node current = nodeList.Head;
		if (current.MinId > id) return id;

		while (current.Next != null && current.MaxId < id)
		{
			current = current.Next;
		}

		if (current.MinId <= id && current.MaxId >= id)
		{
			long offset = current.Id - current.MinId;
			return id + offset;
		}

		return id;
	}
}

class Node
{
	public long Id { get; set; }
	public long MinId { get; set; }
	public long MaxId { get; set; }
	public Node Next { get; set; }

}


class NodeMap
{
	public List<(long, long)> Seeds { get; private set; } = new List<(long, long)>();

	public List<NodeList> Map { get; set; } = new List<NodeList>();

	private static void LoadSeeds(NodeMap map, string line)
	{
		Assert.True(line.StartsWith("seeds:"));
		string pattern = @"\b\d+\b";
		MatchCollection matches = Regex.Matches(line, pattern);
		for (int i = 0; i < matches.Count; i++)
		{
			Match match = matches[i];
			long start = long.Parse(match.Value);
			i++;
			match = matches[i];
			long count = long.Parse(match.Value);
			map.Seeds.Add((start, count));
		}
	}

	public static NodeMap Load(string fileName)
	{
		NodeMap map = new NodeMap();
		// 
		string path = Path.Combine(Utility.GetInputDirectory(), fileName);
		string[] lines = File.ReadAllLines(path);

		/*
		seeds: 79 14 55 13
		*/

		int i = 0;
		string line = lines[i];
		LoadSeeds(map, line);


		NodeList list = ParseNodeList(lines, "seed-to-soil", ref i);
		map.Map.Add(list);

		list = ParseNodeList(lines, "soil-to-fertilizer", ref i);
		map.Map.Add(list);

		list = ParseNodeList(lines, "fertilizer-to-water", ref i);
		map.Map.Add(list);

		list = ParseNodeList(lines, "water-to-light", ref i);
		map.Map.Add(list);

		list = ParseNodeList(lines, "light-to-temperature", ref i);
		map.Map.Add(list);

		list = ParseNodeList(lines, "temperature-to-humidity", ref i);
		map.Map.Add(list);

		list = ParseNodeList(lines, "humidity-to-location", ref i);
		map.Map.Add(list);

		return map;
	}

	internal static NodeList ParseNodeList(string[] lines, string prefix, ref int index)
	{
		NodeList list = new NodeList();
		while (!lines[index].StartsWith(prefix))
		{
			index++;
		}
		index++;
		string pattern = @"\d+\b";
		while (index < lines.Length && !string.IsNullOrEmpty(lines[index]))
		{
			string line = lines[index];
			MatchCollection matches = Regex.Matches(line, pattern);
			Node node = new Node { Id = long.Parse(matches[0].Value), MinId = long.Parse(matches[1].Value) };
			node.MaxId = node.MinId + long.Parse(matches[2].Value) - 1;
			list.Insert(node);
			index++;
		}

		return list;
	}
}

class NodeList
{

	public Node Head { get; set; }
	public void Insert(Node node)
	{

		if (Head == null)
		{
			Head = node;
			return;
		}

		if (node.MinId < Head.MinId)
		{
			node.Next = Head;
			Head = node;
			return;
		}

		Node current = Head;
		while (current.Next != null && current.MinId < node.MinId && current.Next.MinId < node.MinId)
		{
			current = current.Next;
		}

		node.Next = current.Next;
		current.Next = node;

	}

	public long GetLinkedId(long id)
	{
		if (id < Head.MinId) return id;

		Node current = Head;
		while (current.MinId < id && current.Next != null)
		{
			current = current.Next;
		}
		if (current.MinId <= id && current.MaxId >= id)
		{
			//long offset = id - current.MinId; 
			return current.Id;// + offset;
		}
		else
		{
			return id;
		}
	}
}

[Fact]
void LoadSeedsTest()
{
	NodeMap map = NodeMap.Load("sample.txt");
	Assert.Equal(new[] { (79l, 14l), (55l, 13l) }, map.Seeds.ToArray());
}

/*
seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4
*/

[Fact]
void Part2Test()
{
	long result = Part2("sample.txt");
	int expected = 46;
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(52, 50, 0)]
[InlineData(39, 0, 1)]
[InlineData(42, 57, 2)]
[InlineData(88, 18, 3)]
[InlineData(81, 68, 4)]
[InlineData(1, 0, 5)]
[InlineData(56, 60, 6)]
void LoadSoilToFertilizerTest(int expectedHead, int expectedNext, int mapIndex)
{
	NodeMap map = NodeMap.Load("sample.txt");
	Assert.Equal(52, map.Map[0].Head.Id);
	Assert.Equal(50, map.Map[0].Head.Next.Id);
}

[Fact]
void NodeListInsertFirstNodeBecomesHead()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 0, MaxId = 3 });
	Assert.Equal(0, list.Head.Id);
}

[Fact]
void NodeListInsertSecondNodeLessThanFirstBecomesHead()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 13 });
	list.Insert(new Node { Id = 1, MinId = 0, MaxId = 9 });
	Assert.Equal(1, list.Head.Id);
	Assert.Equal(0, list.Head.Next.Id);
}

[Fact]
void NodeListInsertSecondNodeLessThanFirstBecomesTail()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 0, MaxId = 3 });
	list.Insert(new Node { Id = 1, MinId = 4, MaxId = 9 });
	Assert.Equal(0, list.Head.Id);
	Assert.Equal(1, list.Head.Next.Id);
}

[Fact]
void NodeListInsertThirdNodeLessThanFirstBecomesHead()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 19 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 29 });
	list.Insert(new Node { Id = 3, MinId = 0, MaxId = 9 });

	Assert.Equal(3, list.Head.Id);
	Assert.Equal(0, list.Head.Next.Id);
	Assert.Equal(1, list.Head.Next.Next.Id);
}

[Fact]
void NodeListInsertThirdNodeThanBecomesMid()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 14 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 29 });
	list.Insert(new Node { Id = 2, MinId = 15, MaxId = 19 });

	Assert.Equal(0, list.Head.Id);
	Assert.Equal(2, list.Head.Next.Id);
	Assert.Equal(1, list.Head.Next.Next.Id);
}

[Fact]
void NodeListInsertThirdNodeThanBecomesTail()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 14 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 29 });
	list.Insert(new Node { Id = 2, MinId = 30, MaxId = 39 });

	Assert.Equal(0, list.Head.Id);
	Assert.Equal(1, list.Head.Next.Id);
	Assert.Equal(2, list.Head.Next.Next.Id);
}

[Fact]
void NodeListInsertFourthNodeThanBecomesHead()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 14 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 29 });
	list.Insert(new Node { Id = 2, MinId = 30, MaxId = 39 });
	list.Insert(new Node { Id = 3, MinId = 0, MaxId = 9 });

	Assert.Equal(3, list.Head.Id);
	Assert.Equal(0, list.Head.Next.Id);
	Assert.Equal(1, list.Head.Next.Next.Id);
	Assert.Equal(2, list.Head.Next.Next.Next.Id);
}

[Fact]
void NodeListInsertFourthNodeThanBecomesSecond()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 14 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 29 });
	list.Insert(new Node { Id = 2, MinId = 30, MaxId = 39 });
	list.Insert(new Node { Id = 3, MinId = 15, MaxId = 19 });

	Assert.Equal(0, list.Head.Id);
	Assert.Equal(3, list.Head.Next.Id);
	Assert.Equal(1, list.Head.Next.Next.Id);
	Assert.Equal(2, list.Head.Next.Next.Next.Id);
}

[Fact]
void NodeListInsertFourthNodeThanBecomesThird()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 19 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 24 });
	list.Insert(new Node { Id = 2, MinId = 30, MaxId = 39 });
	list.Insert(new Node { Id = 3, MinId = 25, MaxId = 29 });

	Assert.Equal(0, list.Head.Id);
	Assert.Equal(1, list.Head.Next.Id);
	Assert.Equal(3, list.Head.Next.Next.Id);
	Assert.Equal(2, list.Head.Next.Next.Next.Id);
}

[Fact]
void NodeListInsertFourthNodeThanBecomesTail()
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 14 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 29 });
	list.Insert(new Node { Id = 2, MinId = 30, MaxId = 39 });
	list.Insert(new Node { Id = 3, MinId = 40, MaxId = 49 });

	Assert.Equal(0, list.Head.Id);
	Assert.Equal(1, list.Head.Next.Id);
	Assert.Equal(2, list.Head.Next.Next.Id);
	Assert.Equal(3, list.Head.Next.Next.Next.Id);
}

[Theory]
[InlineData(12, 0)]
[InlineData(20, 1)]
[InlineData(29, 1)]
[InlineData(25, 1)]
[InlineData(32, 2)]
[InlineData(46, 3)]
[InlineData(9, 9)]
[InlineData(16, 16)]
[InlineData(50, 50)]
void FindInMapTestsReturnsCorrectId(int value, int expectedId)
{
	NodeList list = new NodeList();
	list.Insert(new Node { Id = 0, MinId = 10, MaxId = 14 });
	list.Insert(new Node { Id = 1, MinId = 20, MaxId = 29 });
	list.Insert(new Node { Id = 2, MinId = 30, MaxId = 39 });
	list.Insert(new Node { Id = 3, MinId = 40, MaxId = 49 });

	long expected = 63;
	long result = SeedLocation.FindIdInMap(list, 63);
	Assert.Equal(expected, result);
}