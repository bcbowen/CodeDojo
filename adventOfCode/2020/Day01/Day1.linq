<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	Node candidateTree = null;
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//const string path = @"C:\dev\adventOfCode\Day1\inputs.txt";
	int candidate = -1; 
	using (StreamReader reader = new StreamReader(path)) 
	{
		int value;
		string s;
		while((s = reader.ReadLine()) != null)
		{
			if (int.TryParse(s, out value))
			{
				candidate = 2020 - value;
				if (candidateTree == null)
				{
					candidateTree = new Node(candidate);
				}
				else
				{
					if (candidateTree.Contains(value))
					{
						break;
					}
					else
					{
						candidateTree.Insert(candidate);
					}
				}
			}
			
		}
		reader.Close();
	}
	Console.WriteLine($"Value 1: {2020 - candidate}"); 
	Console.WriteLine($"Value 2: {candidate}"); 
	Console.WriteLine($"Product: {(2020 - candidate) * candidate}"); 
	
	Console.WriteLine($"Has 2000: {candidateTree.Contains(2020 - 2000)}"); 
	Console.WriteLine($"Has 694: {candidateTree.Contains(2020 - 694)}"); 
}


class Node 
{
	public Node Left {get; set;}
	public Node Right { get; set; }
	public int Value {get; set;}

	public Node(int value)
	{
		Value = value;
	}

	public bool Contains(int value) 
	{
		if (Value == value) return true;
		if (value < Value)
		{
			if (Left == null) return false;
			return Left.Contains(value);
		}
		else
		{
			if (Right == null) return false;
			return Right.Contains(value);
		}
	}

	public void Insert(int value)
	{
		if (Value == value)
		{
			return;
		}
		else if (value < Value)
		{
			if (Left == null)
			{
				Left = new Node(value);
			}
			else 
			{
				Left.Insert(value);
			}
		}
		else
		{
			if (Right == null)
			{
				Right = new Node(value);
			}
			else
			{
				Right.Insert(value);
			}
		}
	}
}