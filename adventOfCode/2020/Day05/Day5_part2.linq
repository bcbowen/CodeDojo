<Query Kind="Program" />

#load "..\..\Utilities.linq"
void Main()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	//string path = Path.Combine(Utility.GetInputDirectory(), "sample.txt";
	List<int> seats = new List<int>();

	using (StreamReader reader = new StreamReader(path))
	{
		string line = ""; 
		while ((line = reader.ReadLine()) != null)
		{
			Seat seat = Seat.Parse(line);
			seats.Add(seat.SeatId); 
		}
		
		reader.Close();
	}

	seats.Sort();
	int lastSeat = seats[0];
	for (int i = 1; i < seats.Count; i++)
	{
		if (seats[i] != lastSeat + 1)
		{
			Console.WriteLine($"your seat: {lastSeat + 1}");
			break;
		}
		else 
		{
			lastSeat = seats[i]; 
		}
	}
	

}

internal class Seat 
{
	public int Row {get;set;}
	public int Column { get; set; }
	public int SeatId
	{
		get { return Row * 8 + Column; }
	}

	public static Seat Parse(string pass)
	{
		return new Seat { Row = GetRow(pass), Column = GetColumn(pass) };	
		
	}

	private static int GetRow(string pass)
	{
		double lower = 0;
		double upper = 127;

		for (int i = 0; i < 6; i++)
		{
			switch (pass[i])
			{
				case 'F':
					upper = upper - Math.Floor((upper - lower) / 2) - 1;
					break;
				case 'B':
					lower = lower + Math.Ceiling((upper - lower) / 2);
					break;
			}
		}
		if (pass[6] == 'F') 
		{
			return (int)lower;
		}
		else
		{
			return (int)upper;
		}

	}

	private static int GetColumn(string pass)
	{
		double lower = 0;
		double upper = 7;

		for (int i = 7; i < 9; i++)
		{
			switch (pass[i])
			{
				case 'L':
					upper = upper - Math.Floor((upper - lower) / 2) - 1;
					break;
				case 'R':
					lower = lower + Math.Ceiling((upper - lower) / 2);
					break;
			}
		}
		if (pass[9] == 'L')
		{
			return (int)lower;
		}
		else
		{
			return (int)upper;
		}
	}
}