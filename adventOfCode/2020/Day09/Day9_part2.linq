<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	
	//const int preambleLength = 5;
	const int preambleLength = 25;
	List<long> messageFields = new List<long>(1024);

	long value = 0;
	using (StreamReader reader = new StreamReader(path))
	{
		string line = "";

		while ((line = reader.ReadLine()) != null)
		{
			value = long.Parse(line);
			messageFields.Add(value);

		}
		reader.Close();
	}

	// 1: Find value that does not fit (value)
	for (int v = preambleLength; v < messageFields.Count(); v++)
	{
		bool isValid = false;
		value = messageFields[v];
		for(int i = v - preambleLength; i < v - 1; i++)
		{
			if (isValid) break;
			for (int j = v - preambleLength + 1; j < v; j++)
			{
				if (messageFields[i] + messageFields[j] == value)
				{
					isValid = true;
					break;
				}
			}
		} 	
		if (!isValid) break;
	}

	Console.WriteLine($"value: {value}"); 
	
	// 2: Find contiguous values that total value
	long total = 0; 
	int startIndex = 0; 
	int endIndex = 0;
	bool done = false;

	for (int i = 0; i < messageFields.Count() - 1; i++)
	{
		if (done) break;
		total += messageFields[i]; 
		for (int j = i + 1; j < messageFields.Count(); j++) 
		{
			total += messageFields[j];
			if (total == value)
			{ 
				startIndex = i;
				endIndex = j;
				done = true; 
				break;
			}
			else if (total > value) 
			{
				total = 0;
				break;
			}
		}
	}
	
	Console.WriteLine($"startIndex: {startIndex}; endIndex: {endIndex}");
	Console.WriteLine("values: ");
	for(int i = startIndex; i <= endIndex; i++)
	{
		Console.WriteLine($"{messageFields[i]}"); 
	}
	Console.WriteLine();
	
	long min = int.MaxValue;
	long max = 0;
	for (int i = startIndex; i <= endIndex; i++)
	{
		if (messageFields[i] < min) { min = messageFields[i]; }
		if (messageFields[i] > max) { max = messageFields[i]; }
	}

	Console.WriteLine($"min: {min}; max: {max}; finalAnswer: {min + max}");
}


