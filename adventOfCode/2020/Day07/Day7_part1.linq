<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample2.txt";
	
	List<BagRule> rules = new List<BagRule>(); 
	
	using (StreamReader reader = new StreamReader(path))
	{
		string line = "";
		while ((line = reader.ReadLine()) != null)
		{
			rules.Add(BagRule.Parse(line));
		}
		reader.Close();
	}

	const string queryName = "shiny gold bag";
	int count = BagRule.GetBagContainers(rules, Bag.Parse(queryName)).Count();
	Console.WriteLine($"count: {count}");
}

internal class BagQuantity 
{
	public Bag Bag { get; set; }
	public int Quantity { get; set; }

	public static BagQuantity Parse(string name)
	{
		// 1 drab blue bag
		string[] fields = name.Split(" ");
		return Parse(fields);
	}

	public static BagQuantity Parse(string[] fields)
	{
		BagQuantity bq = new BagQuantity();
		if (fields.Length > 2)
		{
			bq.Quantity = int.Parse(fields[0]);
			bq.Bag = Bag.Parse(fields.Skip(1).Take(2).ToArray());
		}

		return bq;
	}
}

internal class Bag 
{
	public string Adjective { get; set; }
	public string Color { get; set; }

	public static Bag Parse(string name) 
	{		
		// clear red
		string[] fields = name.Split(" ");
		return Parse(fields);
		
	}

	public static Bag Parse(string[] fields)
	{
		Bag bag = new Bag();
		if (fields.Length > 1)
		{
			bag.Adjective = fields[0];
			bag.Color = fields[1];
		}

		return bag;
	}
}

internal class BagRule 
{
	public Bag ContainerBag { get; set; }
	public List<BagQuantity> Bags { get ; private set; }

	public BagRule() 
	{
		Bags = new List<BagQuantity>();
	}

	public BagQuantity Find(string name) 
	{
		BagQuantity bq = null;
		string[] fields = name.Split(" ");
		if (fields.Length > 2)
		{
			bq = Bags.FirstOrDefault(b => b.Bag.Adjective == fields[0] && b.Bag.Color == fields[1]);
		}
		return bq;
	}

	public static List<Bag> GetBagContainers(List<BagRule> rules, Bag bag)
	{
		List<Bag> containerBags = new List<Bag>();
		foreach(BagRule rule in rules)
		{
			BagQuantity bq = rule.Bags.FirstOrDefault(b => b.Bag.Adjective == bag.Adjective && b.Bag.Color == bag.Color);
			if (bq != null)
			{
				if (!containerBags.Any(b => b.Adjective == rule.ContainerBag.Adjective && b.Color == rule.ContainerBag.Color))
				{
					containerBags.Add(rule.ContainerBag);
					//Console.WriteLine($"Counting {rule.ContainerBag.Adjective} {rule.ContainerBag.Color}");
				}
				
			}
		}

		foreach(Bag container in containerBags) 
		{
			containerBags = containerBags.Union(GetBagContainers(rules, container)).ToList(); 
		}
		
		return containerBags;
	}
	
	public static BagRule Parse(string rule)
	{
		StringBuilder name = new StringBuilder(); 
		// clear red bags contain 1 drab blue bag, 5 striped fuchsia bags, 5 striped brown bags, 3 clear silver bags.
		string[] fields = rule.Split(' ');
		//string field;
		BagRule newRule = new BagRule();
		Bag bag = Bag.Parse(fields.Take(2).ToArray());
		newRule.ContainerBag = bag;

		int fieldIndex = 4;
		while(fieldIndex < fields.Count()) 
		{
			// 1 drab blue bag, 5 striped fuchsia bags, 5 striped brown bags, 3 clear silver bags.
			// dotted black bags contain no other bags.
			int quantity;
			if (int.TryParse(fields[fieldIndex++], out quantity))
			{
				BagQuantity bq = new BagQuantity() 
								{
									Quantity = quantity,
									Bag = Bag.Parse(fields.Skip(fieldIndex).Take(2).ToArray())
								};
				newRule.Bags.Add(bq);
			}
			
			
			fieldIndex += 3;
		}
		
		return newRule; 
	}
}