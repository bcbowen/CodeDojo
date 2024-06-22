<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities"
void Main()
{
	RunTests(); 
	ChipFactory factory = Part1(); 
	Part2(factory);
}

ChipFactory Part1() 
{
	ChipFactory factory = new ChipFactory(); 
	factory.DoStuff(); 
	return factory; 
}

void Part2(ChipFactory factory) 
{
	//Console.WriteLine($"Part2: {factory.Bots[0].Chips[0] * factory.Bots[1].Chips[0] * factory.Outputs[0].Chips[0]}"); 
	
	int output0 = factory.Outputs.First(o => o.Value == 0).Chips[0];
	int output1 = factory.Outputs.First(o => o.Value == 1).Chips[0];
	int output2 = factory.Outputs.First(o => o.Value == 2).Chips[0];
	Console.WriteLine("Part2: " + output0 * output1 * output2); 
}

class ChipFactory 
{
	public ChipFactory() 
	{
		Bots = new List<Bot>(); 
		Outputs = new List<Output>(); 
	}

	public List<Bot> Bots { get; private set; }
	public List<Output> Outputs {get; private set;}

	public void DoStuff() 
	{
		string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
		string[] commands = File.ReadAllLines(path);
		foreach (string command in commands) 
		{
			ProcessCommand(command); 
		}
		Console.WriteLine("Part1 done, time for a Guinness."); 
	}

	internal void ProcessCommand(string command)
	{
		if (command.StartsWith("value"))
		{
			ProcessValueCommand(command); 
		}
		else 
		{
			ProcessBotCommand(command); 
		}
		
	}

	internal void ProcessValueCommand(string command)
	{
		/*
		value 37 goes to bot 1
		value 61 goes to bot 144
		*/
		string[] words = command.Split(' ');
		int value = int.Parse(words[1]);
		int botNumber = int.Parse(words[5]);
		Bot bot;
		if (!Bots.Any(b => b.Value == botNumber)) 
		{
			bot = new Bot(botNumber);
			Bots.Add(bot);
			
		}
		else
		{
			bot = Bots.First(b => b.Value == botNumber);
		}
		bot.Receive(value);
	}

	internal void ProcessBotCommand(string command)
	{
		string[] words = command.Split(' ');
		Bot bot;
		int botId = int.Parse(words[1]);
		if (Bots.Any(b => b.Value == botId))
		{
			bot = Bots.First(b => b.Value == botId);
		}
		else
		{
			bot = new Bot(botId);
			Bots.Add(bot);
		}

		int lowId = int.Parse(words[6]);
		IReceiver lowReceiver;
		if (words[5] == "bot")
		{
			if (!Bots.Any(b => b.Value == lowId)) 
			{
				Bots.Add(new Bot(lowId)); 
			}
			lowReceiver = Bots.First(b => b.Value == lowId);
		}
		else
		{
			if (!Outputs.Any(o => o.Value == lowId)) 
			{
				Outputs.Add(new Output(lowId));
			}
			lowReceiver = Outputs.First(o => o.Value == lowId); 
		}

		int highId = int.Parse(words[^1]);
		IReceiver hiReceiver;
		if (words[^2] == "bot")
		{
			if (!Bots.Any(b => b.Value == highId)) 
			{
				Bots.Add(new Bot(highId)); 
			}
			hiReceiver = Bots.First(b => b.Value == highId);
		}
		else
		{
			if (!Outputs.Any(o => o.Value == highId)) 
			{
				Outputs.Add(new Output(highId));
			}
			hiReceiver = Outputs.First(o => o.Value == highId);
		}

		bot.LoTarget = lowReceiver;
		bot.HiTarget = hiReceiver;
		if (bot.Chips.Count == 2)
		{
			//if (new[] {123, 191, 182}.Contains(bot.Value)) Console.WriteLine(bot.Chips.Min(c => c));
			bot.LoTarget.Receive(bot.Chips.Min(c => c)); 
			bot.HiTarget.Receive(bot.Chips.Max(c => c)); 
		}
		
		/*
		bot 58 gives low to bot 180 and high to bot 123
		bot 205 gives low to bot 169 and high to bot 3
		bot 91 gives low to bot 76 and high to bot 84
		bot 93 gives low to bot 122 and high to bot 100
		bot 76 gives low to bot 147 and high to bot 89
		bot 102 gives low to bot 11 and high to bot 23
		bot 43 gives low to output 11 and high to output 12
		*/
	}
}



interface IReceiver 
{
	public void Receive(int value);
	public int Value {get; }
}

class Bot : IReceiver
{
	public Bot(int value) 
	{
		Value = value; 
		Chips = new List<int>(); 
	}

	public void Receive(int value) 
	{
		// part1: bot that processes 61 and 17 is the answer
		Chips.Add(value);
		if (Chips.Count == 2)
		{
			if (Chips.Contains(61) && Chips.Contains(17)) Console.WriteLine($"Bot {Value} has chips 61 and 17"); 
			if (HiTarget != null) HiTarget.Receive(Chips.Max(c => c)); 
			if (LoTarget != null) LoTarget.Receive(Chips.Min(c => c)); 
		}
	}
	
	public List<int> Chips;

	public int Value { get; private set; }
	public IReceiver HiTarget { get; set; }
	public IReceiver LoTarget {get; set;}
}

class Output : IReceiver 
{
	public Output(int value) 
	{
		Value = value;	
	}
	
	public int Value {get; private set;}
	public List<int> Chips = new List<int>();
	public void Receive(int value) 	
	{
		Chips.Add(value);
	}
}



#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion