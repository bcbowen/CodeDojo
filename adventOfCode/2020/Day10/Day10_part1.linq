<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample2.txt";
	
	List<int> adapters = new List<int>(128);

	int diff1 = 0; 
	int diff3 = 0;
	using (StreamReader reader = new StreamReader(path))
	{
		string line = "";
		
		while ((line = reader.ReadLine()) != null)
		{			
			int value = int.Parse(line);
			adapters.Add(value);
		}
		reader.Close();
	}
	
	adapters.Sort();
	int previous = 0;

	foreach(int value in adapters)
	{
		if (value - previous == 1) diff1++;
		if (value - previous == 3) diff3++;
		Console.WriteLine($"{value} {value - previous} {diff1} {diff3}"); 
		previous = value;
	}
	diff3++;
	Console.WriteLine("----"); 
	Console.WriteLine($"{diff1} X {diff3}: {diff1 * diff3}");
}


