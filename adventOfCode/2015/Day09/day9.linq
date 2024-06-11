<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests(); 
	string file = "input.txt"; 
	RouteInfo routeInfo = new RouteInfo(file);
	(RouteNode root, int min, int max) = routeInfo.LoadRouteTree();
	Console.WriteLine($"Min {min}; Max {max}"); 
}

(RouteNode root, int min, int max) GetRoutes(string inputFile)
{
	RouteInfo routeInfo = new RouteInfo(inputFile); 
	(RouteNode root, int min, int max) = routeInfo.LoadRouteTree(); 
	return (root, min, max); 
}

class RouteInfo 
{
	public RouteInfo(string fileName) 
	{
		CityDistances = new List<CityDistance>(); 		
		Cities = new List<string>();
		LoadCities(fileName); 
	}

	public List<CityDistance> CityDistances { get; private set; }
	public List<string> Cities {get; private set; }

	private void LoadCities(string fileName) 
	{
		string path = Path.Combine(Utility.GetInputDirectory(), fileName);
		using (StreamReader reader = new StreamReader(path))
		{
			string line;
			while((line = reader.ReadLine()) != null) 
			{
				CityDistance cd = CityDistance.Parse(line); 
				CityDistances.Add(cd); 
				if (!Cities.Contains(cd.Cities[0])) Cities.Add(cd.Cities[0]); 
				if (!Cities.Contains(cd.Cities[1])) Cities.Add(cd.Cities[1]); 
			}
			reader.Close(); 
		}
	}

	public (RouteNode tree, int min, int max) LoadRouteTree() 
	{
		int min = int.MaxValue; 
		int max = 0; 
		RouteNode root = new RouteNode("root", 0);
		RouteNode current = root;
		Queue<RouteNode> nodeQueue = new Queue<RouteNode>();
		RouteNode next;
		foreach(string city in Cities) 
		{
			next = new RouteNode(city, 0); 
			next.AvailableCities.AddRange(Cities.Where(c => c != city)); 
			current.Nodes.Add(next); 
			nodeQueue.Enqueue(next);
		}
		while(nodeQueue.Count > 0) 
		{
			int currentLevel = nodeQueue.Count; 
			for (int i = 0; i < currentLevel; i++) 
			{
				current = nodeQueue.Dequeue();
				foreach(string city in current.AvailableCities) 
				{
					next = new RouteNode(city, CityDistance.GetDistance(CityDistances, current.Name, city) + current.DistanceTraveled);
					next.AvailableCities.AddRange(current.AvailableCities.Where(c => c != city && c != current.Name)); 
					current.Nodes.Add(next); 
					nodeQueue.Enqueue(next); 
				}
				// if this is a leaf, see if it is min or max
				if (current.Nodes.Count == 0)
				{
					min = Math.Min(min, current.DistanceTraveled); 
					max = Math.Max(max, current.DistanceTraveled); 
				}
			}
		}
		
		return (root, min, max); 
	}
}

class RouteNode 
{
	public List<RouteNode> Nodes { get; } = new List<RouteNode>();
	public List<string> AvailableCities { get; } = new List<string>();

	public string Name {get; private set; }
	public int DistanceTraveled {get; private set;}

	public RouteNode(string name, int distance) 
	{
		Name = name; 
		DistanceTraveled = distance;
	}
}

class CityDistance 
{
	public string[] Cities { get; private set; }
	public int Distance {get; private set;}
	
	public CityDistance(string city1, string city2, int distance)
	{
		Cities = new string[] { city1, city2 }; 
		Distance = distance; 
	}

	public static CityDistance Parse(string value)
	{
		string[] fields = value.Split(' ');
		int distance = int.Parse(fields[4]);
		return new CityDistance(fields[0], fields[2], distance); 
	}

	public static int GetDistance(List<CityDistance> cds, string city1, string city2) 
	{
		CityDistance cd = cds.FirstOrDefault(c => c.Cities.Contains(city1) && c.Cities.Contains(city2));
		if (cd == null) throw new ArgumentException($"No match for cities {city1} and {city2}"); 
		return cd.Distance; 
	}
}

/*

London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141

Dublin -> London -> Belfast = 982
London -> Dublin -> Belfast = 605
London -> Belfast -> Dublin = 659
Dublin -> Belfast -> London = 659
Belfast -> Dublin -> London = 605
Belfast -> London -> Dublin = 982
*/
[Fact]
void Test() 
{
	int expectedMin = 605; 
	int expectedMax = 982; 
	string file = "sample.txt"; 
	RouteInfo routeInfo = new RouteInfo(file); ;
	(RouteNode root, int min, int max) = routeInfo.LoadRouteTree(); 
	Assert.Equal(expectedMin, min); 
	Assert.Equal(expectedMax, max); 
}

[Theory]
[InlineData("Norrath to AlphaCentauri = 136", "Norrath", "AlphaCentauri", 136)]
[InlineData("London to Belfast = 518", "London", "Belfast", 518)]
void ParseCityDistanceTest(string line, string city1, string city2, int distance)
{
	CityDistance cd = CityDistance.Parse(line);
	Assert.Contains(city1, cd.Cities); 
	Assert.Contains(city2, cd.Cities); 
	Assert.Equal(distance, cd.Distance); 
}