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
		bool groupBust = false;
		string line = "";
		while ((line = reader.ReadLine()) != null)
		{
			if (line == "")
			{
				questionTotal += qt.Tally;
				qt = new QuestionTallier();
				groupBust = false;
			}
			else
			{
				if (!groupBust)
				{
					int result = qt.TallyLine(line);
					if (result == 0) groupBust = true;
				}
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
		Questions = null;	
	}

	private List<char> Questions { get; set; }
	public int Tally 
	{
		get { return Questions.Count; } 
	}
	
	public int TallyLine(string line)
	{
		List<char> newQuestions =  new List<char>();
		foreach(char q in line)
		{
			if (!newQuestions.Contains(q))
			{
				newQuestions.Add(q);
			}
		}

		if (Questions == null) 
		{
			Questions = newQuestions;	
		}
		else
		{
			Questions = Questions.Intersect(newQuestions).ToList();	
		}
		return Questions.Count();
	}
}