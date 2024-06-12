<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	//string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt");
	
	List<int> adapters = new List<int>(128);

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
	int paths = 0;
	for(int i = 0; i < adapters.Count(); i++)
	{
		paths += CountPaths(adapters, i); 
	}
	
	paths++;
	
	Console.WriteLine("----"); 
	Console.WriteLine($"paths: {paths}");
}

/// <summary> Count the paths from the current element to the next element</summary>
private int CountPaths(List<int> adapters, int index) 
{
	int diff;
	int paths = 0;
	for (int i = 1; i < 4; i++) 
	{
		if (index < adapters.Count() - i)
		{
			diff = adapters[index + i] - adapters[index];
			if (diff < 4)
			{
				paths++;
			}
			else
			{
				break;
			}
		}
		else
		{
			break;
		}
	}
	Console.WriteLine($"Paths from {adapters[index]}: {paths}"); 
	return paths > 1 ? paths : 0;
}


private string GetQueryDirectory()
{
	FileInfo file = new FileInfo(Util.CurrentQueryPath);
	return file.DirectoryName;
}
