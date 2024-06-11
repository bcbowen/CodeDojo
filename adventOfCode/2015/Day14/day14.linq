<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests();  
	Part1("input.txt", 2503); 
	Part2("input.txt", 2503); 
}

void Part1(string fileName, int seconds) 
{
	int max = 0;

	List<Reindeer> deers = Reindeer.Load(fileName);
	foreach(Reindeer deer in deers) 
	{
		int distance = deer.GetDistanceTraveled(seconds); 
		max = Math.Max(distance, max);
	}
	Console.WriteLine($"Winning distance part 1: {max}"); 
}

void Part2(string fileName, int seconds) 
{
	List<Reindeer> deers = Reindeer.Load(fileName);
	int winningDistance = 0; 
	List<Reindeer> winners = new List<Reindeer>(); 
	for(int second = 1; second <= seconds; second++) 
	{
		foreach (Reindeer deer in deers)
		{
			if (second > deer.RestUntil && second > deer.GoUntil) 
			{
				deer.GoUntil = second + deer.GoSeconds - 1; 
			}
			
			if (second <= deer.GoUntil) 
			{
				
				deer.Go();
				if (deer.DistanceTraveled > winningDistance) 
				{
					winners.Clear();
					winners.Add(deer);
					winningDistance = deer.DistanceTraveled;
				}
				else if (deer.DistanceTraveled == winningDistance) 
				{
					winners.Add(deer);
				}

				if (second == deer.GoUntil) 
				{
					deer.RestUntil = second + deer.RestSeconds; 
				}
			}

			
		}
		foreach (Reindeer deer in winners) 
		{
			deer.Score++;
		}
	}
	
	Console.WriteLine($"Winning points part 2: {deers.Max(d => d.Score)}");
}

// You can define other methods, fields, classes and namespaces here
class Reindeer 
{
	public string Name { get; set;}
	public int KPS { get; set;}
	public int GoSeconds { get; set;}
	public int RestSeconds { get; set; }
	public int Score { get; set; }
	public int DistanceTraveled { get; set; }
	public int RestUntil { get; set; }
	public int GoUntil {get; set;}

	public void Go()
	{
		DistanceTraveled += KPS; 
	}
	public int GetDistanceTraveled(int secondsTraveled) 
	{
		int cycleTime = GoSeconds + RestSeconds; 
		if (secondsTraveled <= GoSeconds) return secondsTraveled * KPS; 
		if (secondsTraveled <= cycleTime) return GoSeconds * KPS; 
		
		int cycles = secondsTraveled / cycleTime; 
		int finalSeconds = Math.Min(secondsTraveled % cycleTime, GoSeconds); 
		int distance = cycles * (KPS * GoSeconds); 
		distance += finalSeconds * KPS; 
		return distance; 
	}

	public static Reindeer Parse(string line) 
	{
		// Dasher can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
		string[] fields = line.Split(' ');
		Reindeer deer = new Reindeer(); 
		deer.Name = fields[0]; 
		deer.KPS = int.Parse(fields[3]); 
		deer.GoSeconds = int.Parse(fields[6]); 
		deer.RestSeconds = int.Parse(fields[13]);
		deer.GoUntil = deer.GoSeconds; 
		return deer; 
	}

	public static List<Reindeer> Load(string fileName) 
	{
		List<Reindeer> deer = new List<Reindeer>();
		string path = Path.Combine(Utility.GetInputDirectory(), fileName);
		using (StreamReader reader = new StreamReader(path)) 
		{
			string line;
			while((line = reader.ReadLine()) != null) 
			{
				deer.Add(Reindeer.Parse(line)); 
			}
			reader.Close(); 
		}
		return deer; 
	}
}


[Theory]
[InlineData("Comet", 14, 10, 127, 1, 14)]
[InlineData("Dancer", 16, 11, 162, 1, 16)]
[InlineData("Comet", 14, 10, 127, 10, 140)]
[InlineData("Dancer", 16, 11, 162, 10, 160)]
[InlineData("Comet", 14, 10, 127, 11, 140)]
[InlineData("Dancer", 16, 11, 162, 11, 176)]
[InlineData("Comet", 14, 10, 127, 14, 140)]
[InlineData("Dancer", 16, 11, 162, 14, 176)]
[InlineData("Comet", 14, 10, 127, 138, 154)]
[InlineData("Dancer", 16, 11, 162, 138, 176)]
[InlineData("Comet", 14, 10, 127, 146, 266)]

[InlineData("Comet", 14, 10, 127, 1000, 1120)]
[InlineData("Dancer", 16, 11, 162, 1000, 1056)]
void DistanceTest(string name, int kps, int goSeconds, int restSeconds, int seconds, int expectedDistance) 
{
	Reindeer r = new Reindeer { Name = name, KPS = kps, GoSeconds = goSeconds, RestSeconds = restSeconds};
	int distance = r.GetDistanceTraveled(seconds); 
	Assert.Equal(expectedDistance, distance); 
}
/*
Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.

After one second, Comet has gone 14 km, while Dancer has gone 16 km. 
After ten seconds, Comet has gone 140 km, while Dancer has gone 160 km. 
On the eleventh second, Comet begins resting (staying at 140 km), and Dancer continues on 
for a total distance of 176 km. 
On the 12th second, both reindeer are resting. They continue to rest until the 138th 
second, when Comet flies for another ten seconds. 
On the 174th second, Dancer flies for another 11 seconds.

In this example, after the 1000th second, both reindeer are resting, and Comet is in the lead at 1120 km (poor 
Dancer has only gotten 1056 km by that point). So, in this situation, Comet would win (if the race ended at 1000 
seconds).

Given the descriptions of each reindeer (in your puzzle input), after exactly 2503 seconds, what distance has the 
winning reindeer traveled?
*/
[Fact]
void ParseTest() 
{
	string line = "Cupid can fly 12 km/s for 4 seconds, but then must rest for 43 seconds."; 
	Reindeer deer = Reindeer.Parse(line); 
	Assert.Equal("Cupid", deer.Name);
	Assert.Equal(12, deer.KPS);
	Assert.Equal(4, deer.GoSeconds); 
	Assert.Equal(43, deer.RestSeconds); 
}

[Fact]
void LoadTest()
{
	string fileName = "sample.txt"; 
	List<Reindeer> deer = Reindeer.Load(fileName); 
	Assert.Equal(2, deer.Count());
}