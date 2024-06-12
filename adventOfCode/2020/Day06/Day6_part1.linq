<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample2.txt";
	QuestionTallier qt = new QuestionTallier(); 
	int questionTotal = 0;
	using (StreamReader reader = new StreamReader(path))
	{
		string line = "";
		while ((line = reader.ReadLine()) != null)
		{
			if (line == "")
			{
				questionTotal += qt.Tally;
				qt = new QuestionTallier();
			}
			else 
			{
				qt.TallyLine(line);
			}
		}
		reader.Close();
		
		questionTotal += qt.Tally;
	}

	Console.WriteLine($"questionTotal: {questionTotal}");
}

internal class QuestionTallier 
{
	public QuestionTallier() 
	{
		Questions = new List<char>();	
	}

	private List<char> Questions { get; set; }
	public int Tally 
	{
		get { return Questions.Count(); } 
	}
	
	public int TallyLine(string line)
	{
		int added = 0;
		foreach(char q in line)
		{
			if (!Questions.Contains(q))
			{
				//Console.WriteLine($"Adding {q}");
				Questions.Add(q);
				added++;
			}
		}
		return added;
	}
}