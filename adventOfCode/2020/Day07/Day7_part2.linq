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
	BagNode node = BagRule.LoadBagQuantities(rules, new BagQuantity(Bag.Parse(queryName), 1));
	int count = node.GetBagCount() - 1; // subtract one for outer bag, just want inner bag count
	BagNode.ShowNodes(node, 1);
	// 9540 is too high
	Console.WriteLine($"count: {count}");
}

internal class BagQuantity 
{
	public Bag Bag { get; set; }
	public int Quantity { get; set; }

	public BagQuantity() {}

	public BagQuantity(Bag bag, int quantity) 
	{
		Bag = bag; 
		Quantity = quantity;
	}

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

	public override string ToString()
	{
		return $"{Quantity} {Bag}";
	}

	public static bool operator ==(BagQuantity lhs, BagQuantity rhs) 
	{
		if (ReferenceEquals(lhs, rhs)) return true;
		if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;
		
		return lhs.Bag == rhs.Bag && 
			lhs.Quantity == rhs.Quantity; 
	}
	
	public static bool operator !=(BagQuantity lhs, BagQuantity rhs)
	{
		return !(lhs == rhs);
	}
}

internal class Bag 
{
	public string Adjective { get; set; }
	public string Color { get; set; }

	public Bag() {}

	public Bag(string adjective, string color) 
	{
		Adjective = adjective; 
		Color = color; 
	}

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

	public override string ToString()
	{
		return $"{Adjective} {Color}";
	}

	public static bool operator == (Bag lhs, Bag rhs) 
	{
		if (ReferenceEquals(lhs, rhs)) return true;
		if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;
		
		return lhs.Adjective == rhs.Adjective && 
			lhs.Color == rhs.Color; 
	}

	public static bool operator !=(Bag lhs, Bag rhs) 
	{
		return !(lhs == rhs);
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



	public static BagNode LoadBagQuantities(List<BagRule> rules, BagQuantity bagQuantity, BagNode node = null)
	{
		if (node == null)
		{
			node = new BagNode(bagQuantity);
		}
		
		BagRule rule = rules.FirstOrDefault(r => r.ContainerBag == bagQuantity.Bag);
		if (rule != null)
		{
			foreach (BagQuantity bq in rule.Bags)
			{
				node.Add(rule.ContainerBag, bq);
				LoadBagQuantities(rules, bq, node);
			}
		}
		
		return node;
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

internal class BagNode
{
	public BagQuantity BagInfo { get; set; }
	public List<BagNode> Children { get; set; }

	public BagNode() 
	{
		Children = new List<BagNode>();
	}

	public BagNode(BagQuantity info) : this()
	{
		BagInfo = info;
	}

	public int GetBagCount()
	{
		int count = 0;
		foreach (BagNode child in Children)
		{
			count += child.GetBagCount();
		}
		count *= BagInfo.Quantity;
		count += BagInfo.Quantity;
		return count;
	}

	public void Add(Bag parent, BagQuantity bagQuantity)
	{
		if (BagInfo.Bag == parent && !Children.Any(c => c.BagInfo == bagQuantity)) 
		{
			Children.Add(new BagNode {BagInfo = bagQuantity} );
		}
		
		foreach (BagNode child in Children)
		{
			if (child.BagInfo.Bag == parent && !child.Children.Any(c => c.BagInfo == bagQuantity))
			{
				child.Children.Add(new BagNode {BagInfo = bagQuantity} );
			}
			else 
			{
				child.Add(parent, bagQuantity);
			}
			
		}
	}

	public static void ShowNodes(BagNode node, int level) 
	{
		string spacer = new String('-', level);
		Console.WriteLine($"{level} {node.BagInfo.ToString()}");
		foreach(BagNode child in node.Children) 
		{
			ShowNodes(child, level + 1);
		}
	}
}