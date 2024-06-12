<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample2.txt";
	
	List<Instruction> program = new List<Instruction>(); 
	
	using (StreamReader reader = new StreamReader(path))
	{
		string line = "";
		while ((line = reader.ReadLine()) != null)
		{
			Instruction instruction = Instruction.Parse(line);
			program.Add(instruction);
		}
		reader.Close();
	}

	int accumulator = 0;
	int pointer = 0;
	bool faulted = false;
	bool done = false;
	List<int> executed = new List<int>();
	while (!faulted && !done)
	{
		Instruction i = program[pointer];
		if (executed.Contains(pointer))
		{
			Console.WriteLine($"loop at instruction {pointer}"); 
			faulted = true;
			break;
		}
		else 
		{
			executed.Add(pointer);
		}
		
		switch (i.Command) 
		{
			case "nop": 
				pointer++;
				break;
			case "acc": 
				accumulator += i.Value; 
				pointer++;
				break;
			case "jmp": 
				pointer += i.Value;
				break;
		}
		
		if (pointer < 0)
		{
			faulted = true;
		}
		else if (pointer >= program.Count())
		{
			done = true;
		}
	}
	
	Console.WriteLine($"accumulator: {accumulator}");
}

internal class Instruction 
{
	//public int Index {get; set;}
	public string Command { get; set; }
	public int Value {get; set;}

	public static Instruction Parse(string line) 
	{
		string[] fields = line.Split(' ');
		Instruction instruction = new Instruction 
		{
			Command = fields[0], 
			Value = int.Parse(fields[1])
		};
		return instruction;
	}
}
