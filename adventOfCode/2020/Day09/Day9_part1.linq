<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	
	const int preambleLength = 25;
	List<int> messageFields = new List<int>(preambleLength + 1);
	Queue dataQueue = new Queue();
	bool initializing = true;
	int count = 0; 
	int value = 0;
	using (StreamReader reader = new StreamReader(path))
	{
		string line = "";
		
		while ((line = reader.ReadLine()) != null)
		{			
			value = int.Parse(line);
			if (!initializing)
			{
				// remove last element, insert next element
				messageFields.RemoveAt(preambleLength);
			}
			messageFields.Insert(0, value);
			
			
			if (count++ >= preambleLength)
			{
				initializing = false;
			}

			if (!initializing)
			{
				bool valid = false;
				// checkValue
				for (int i = 1; i < messageFields.Count() - 1; i++)
				{
					if (valid) break;
					for (int j = 2; j < messageFields.Count(); j++)
					{
						if (messageFields[i] + messageFields[j] == value)
						{
							valid = true;
						}
					}
				}
				if (!valid) break;
			}
			
		}
		reader.Close();
	}
	
	
	
	Console.WriteLine($"value: {value}");
}


