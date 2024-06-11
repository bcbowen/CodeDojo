<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	
	// what signal is ultimately provided to wire a?: 
	string name = "a"; 
	int part1Result = Part1(name); 
	Part2(name, part1Result); 
}



// You can define other methods, fields, classes and namespaces here

int Part1(string targetWire)
{
	Connections c = new Connections();
	int result = c.GetSignal(targetWire);
	Console.WriteLine($"Part 1 signal for wire {targetWire}: {result}"); 
	return result;
}

void Part2(string targetWire, int part1Result)
{
	Connections c = new Connections();
	Dictionary<string, int> overrides = new Dictionary<string, int>(); 
	overrides.Add("b", part1Result); 
	int result = c.GetSignal(targetWire, overrides);
	Console.WriteLine($"Part 2 signal for wire {targetWire}: {result}");
}

class Connections 
{
	public Connections() 
	{
		Wires = new Dictionary<string, Wire>(); 
	}
	
	public Dictionary<string, Wire> Wires { get; private set; }
	
	public int Value {get; set;}

	public int GetSignal(string targetWire, Dictionary<string, int> overrides = null)
	{
		
		string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
		using (StreamReader reader = new StreamReader(path))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				Wire wire = Wire.Parse(line); 
				Wires.Add(wire.Name, Wire.Parse(line));
			}
			reader.Close();
		}
		if (overrides != null)
		{
			foreach (string key in overrides.Keys)
			{
				Wires[key].Value = overrides[key]; 
			}
		}
		return ProcessCommands(targetWire);
	}

	// NOT source -> destination
	private bool DoNot(string source, string destination)
	{
		Wire sourceWire = Wires[source];
		if (!sourceWire.ValueSet) 
		{
			return false; 
		}
		
		Wire destinationWire = Wires[destination]; 
		destinationWire.Value = ~sourceWire.Value;
		return true;
		
	}

	private bool DoOp(string[] fields)
	{
		/*
		x AND y -> d
		x OR y -> e
		x LSHIFT 2 -> f
		y RSHIFT 2 -> g
		*/
		switch(fields[1]) 
		{
			case "AND": 
				return DoAnd(fields); 
			case "OR": 
				return DoOr(fields); 
			case "RSHIFT": 
			case "LSHIFT": 
				return DoShift(fields); 
			default:
				throw new Exception($"Unrecognized command: {fields[1]}"); 
		}
	}

	private bool DoAnd(string[] fields)
	{
		// x AND y -> d
		Wire destination = Wires[fields[4]];
		int testVal; 
		int xVal;
		int yVal;
		if (int.TryParse(fields[0], out testVal)) 
		{ 
			xVal = testVal;
		} 
		else 
		{
			Wire x = Wires[fields[0]]; 
			if (!x.ValueSet) return false; 
			xVal = x.Value; 
		}

		if (int.TryParse(fields[2], out testVal)) 
		{
			yVal = testVal;
		}
		else
		{
			Wire y = Wires[fields[2]]; 
			if (!y.ValueSet) return false; 
			yVal = y.Value;
		}
		
		
		destination.Value = xVal & yVal; 
		return true;
	}
	
	private bool DoOr(string[] fields)
	{
		// x OR y -> d
		Wire destination = Wires[fields[4]];
		int testVal;
		int xVal;
		int yVal;
		if (int.TryParse(fields[0], out testVal))
		{
			xVal = testVal;
		}
		else
		{
			Wire x = Wires[fields[0]];
			if (!x.ValueSet) return false;
			xVal = x.Value;
		}

		if (int.TryParse(fields[2], out testVal))
		{
			yVal = testVal;
		}
		else
		{
			Wire y = Wires[fields[2]];
			if (!y.ValueSet) return false;
			yVal = y.Value;
		}


		destination.Value = xVal | yVal;
		return true;
	}

	private bool DoShift(string[] fields)
	{
		// x LSHIFT 2 -> f
		Wire destination = Wires[fields[4]];
		Wire x = Wires[fields[0]];
		if (!x.ValueSet) return false;

		int places = int.Parse(fields[2]);
		switch (fields[1]) 
		{
			case "LSHIFT": 
				destination.Value = x.Value << places;
				break;
			case "RSHIFT":
				destination.Value = x.Value >> places;
				break;
			default:
				throw new Exception($"Unexpected command: {fields[1]}"); 
		}
		return true;
	}

	private bool DoAssignment(string[] fields)
	{
		int val;
		Wire destinationWire = Wires[fields[2]]; 
		//123 -> x
		if (int.TryParse(fields[0], out val)) 
		{			
			destinationWire.Value = val;
		}
		else
		{
			Wire sourceWire = Wires[fields[0]]; 
			if (!sourceWire.ValueSet) return false;
			destinationWire.Value = sourceWire.Value; 
		}
		
		return true;
	}
	
	private int ProcessCommands(string targetWire)
	{
		bool assignmentMade = false;
		do
		{
			assignmentMade = false;
			
			foreach (string key in Wires.Keys)
			{
				Wire wire = Wires[key];
				bool result = false;
				if (!wire.ValueSet)
				{
					string[] fields = wire.Command.Split(' ');
					switch (fields.Length)
					{
						case 3: //123 -> x
							result = DoAssignment(fields); 							
							break;
						case 4: // NOT x -> h
							result = DoNot(fields[1], wire.Name);
							break;
						case 5: // y RSHIFT 2 -> g
							result = DoOp(fields);
							break;
						default:
							throw new Exception($"Unrecognized Field Format for command: {wire.Command}");
					}
					if (result)
					{
						assignmentMade = true;
						if (wire.Name == targetWire) return wire.Value;
					} 
				}
			}

		} while (assignmentMade); 
		
		Console.WriteLine("TargetWire not set"); 
		return -1; 
		/*
		123 -> x
		456 -> y
		x AND y -> d
		x OR y -> e
		x LSHIFT 2 -> f
		y RSHIFT 2 -> g
		NOT x -> h
		NOT y -> i
		*/
		
	}


}

class Wire 
{
	public string Name { get; set; }
	private int _value;
	public int Value
	{
		get { return _value; }
		set 
		{
			ValueSet = true;
			_value = value;
		} 
	}
	public string Command { get; set; }
	public bool ValueSet { get; private set; }

	/*
		123 -> x
		456 -> y
		x AND y -> d
		x OR y -> e
		x LSHIFT 2 -> f
		y RSHIFT 2 -> g
		NOT x -> h
		NOT y -> i
	*/
	public static Wire Parse(string line)
	{
		Wire wire = new Wire { Command = line }; 
		string[] parts = line.Split(' ');
		int i = parts.Length - 1;
		while (string.IsNullOrEmpty(parts[i]))
		{
			i--; 
		}
		wire.Name = parts[i]; 
		return wire;
	}
}


[Theory]
[InlineData("123 -> x", "x")]
[InlineData("456 -> y ", "y")]
[InlineData("x AND y -> d", "d")]
[InlineData("x OR y -> e ", "e")]
[InlineData("x LSHIFT 2 -> f", "f")]
[InlineData("NOT x -> h", "h")]
void WireInitTest(string command, string expectedName)
{
	Wire wire = Wire.Parse(command); 
	Assert.Equal(wire.Command, command); 
	Assert.Equal(wire.Name, expectedName);
}
