<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	List<int> values = new List<int>();
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//const string path = @"C:\dev\adventOfCode\Day1\inputs.txt";
	using (StreamReader reader = new StreamReader(path))
	{
		int value;
		string s;
		while ((s = reader.ReadLine()) != null)
		{
			if (int.TryParse(s, out value))
			{
				values.Add(value);
			}

		}
		reader.Close();
	}
	int a = 0;
	int b = 0;
	int c = 0;
	bool found = false;
	int iterations = 0; 
	for (a = 0; a < values.Count - 2; a++)
	{
		iterations++; 
		for (b = 1; b < values.Count - 1; b++) 
		{
			iterations++; 
			for (c = 2; c < values.Count; c++)
			{
				iterations++; 
				if (values[a] + values[b] + values[c] == 2020) 
				{
					found = true;
					break;
				};
			}	
			if (found) break;
		}
		if (found) break;
	}
	Console.WriteLine($"a: {values[a]}");
	Console.WriteLine($"b: {values[b]}");
	Console.WriteLine($"c: {values[c]}");
	Console.WriteLine($"iterations: {iterations}");
	Console.WriteLine($"Product: {values[a] * values[b] * values[c]}");

}

private string GetQueryDirectory()
{
	FileInfo file = new FileInfo(Util.CurrentQueryPath);
	return file.DirectoryName;
}