<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Part1("input.txt");
	Part2("input.txt");
}

// You can define other methods, fields, classes and namespaces here

class Line
{
	// jio a, +8
	string Command { get; set; }
	char Register { get; set; }
	int Value { get; set; }


	/*
	hlf r sets register r to half its current value, then continues with the next instruction.
	tpl r sets register r to triple its current value, then continues with the next instruction.
	inc r increments register r, adding 1 to it, then continues with the next instruction.
	jmp offset is a jump; it continues with the instruction offset away relative to itself.
	jie r, offset is like jmp, but only jumps if register r is even ("jump if even").
	jio r, offset is like jmp, but only jumps if register r is 1 ("jump if one", not odd).
	*/
	public static long RunProgram(List<Line> program, int initialA)
	{
		int currentLineNumber = 0; 
		Line currentLine = program[0]; 
		Dictionary<char, long> registers = new Dictionary<char, long>(); 
		registers.Add('a', initialA); 
		registers.Add('b', 0);
		int nextLine = 0; 

		while (currentLineNumber != -1)
		{
			currentLine = program[currentLineNumber]; 
			switch(currentLine.Command) 
			{
				case "hlf":
					registers[currentLine.Register] /= 2;
					nextLine = currentLineNumber + 1;
					Console.WriteLine($"{currentLine.Register} {currentLine.Command} result {registers[currentLine.Register]}");
					break; 
				case "tpl":
					registers[currentLine.Register] *= 3;
					nextLine = currentLineNumber + 1;
					break; 
				case "inc": 
					registers[currentLine.Register]++; 
					nextLine = currentLineNumber + 1;
					break; 
				case "jmp": 
					nextLine = currentLineNumber + currentLine.Value;
					break; 
				case "jie":
					nextLine = registers[currentLine.Register] % 2 == 0 ? nextLine = currentLineNumber + currentLine.Value : currentLineNumber + 1;
					break; 
				case "jio": 
					nextLine = registers[currentLine.Register] == 1 ? currentLineNumber + currentLine.Value : currentLineNumber + 1;
					break;
				default: 
					nextLine = -1; 
					break;
			}

			currentLineNumber = nextLine >= 0 && nextLine < program.Count ? nextLine : -1; 
			
		}
		
		return registers['b']; 
	}

	public static List<Line> LoadProgram(string file)
	{
		List<Line> program = new List<Line>(); 
		string path = Path.Combine(Utility.GetInputDirectory(), file);
		using(StreamReader reader = new StreamReader(path)) 
		{
			string line;
			while((line = reader.ReadLine()) != null) 
			{
				program.Add(Line.Parse(line));
			}
			
			reader.Close();
		}
		
		return program; 
	}

	static Line Parse(string value)
	{
		Line line = new Line();
		/*
		jio a, +2
		tpl a
		*/
		line.Command = value.Substring(0, 3);
		switch (line.Command) 
		{
			case "jmp":
				line.Value = int.Parse(value.Substring(4));
				break;
			case "jie":
			case "jio":
				line.Register = value[4];
				line.Value = int.Parse(value.Substring(7));
				break;
			default: 
				line.Register = value[4]; 
				break;
		}
		return line;
	}
}

void Part1(string file)
{
	List<Line> program = Line.LoadProgram(file);
	long result = Line.RunProgram(program, 0);
	Console.WriteLine($"Part 1 result: {result}"); 
}

void Part2(string file)
{
	List<Line> program = Line.LoadProgram(file);
	long result = Line.RunProgram(program, 1);
	Console.WriteLine($"Part 2 result: {result}");
}

