<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class ParkingSystem
{
	private int _big; 
	private int _medium; 
	private int _small; 


	public ParkingSystem(int big, int medium, int small)
	{
		_big = big; 
		_medium = medium; 
		_small = small;
	}

	public bool AddCar(int carType)
	{
		switch(carType) 
		{
			case 1: 
				if (_big < 1) return false;
				_big--; 
				break;
			case 2: 
				if (_medium < 1) return false;
				_medium--; 
				break;
			case 3: 
				if (_small < 1) return false;
				_small--; 
				break;
		}
		return true;
	}
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1Test() 
{
	ParkingSystem system = new ParkingSystem(1, 1, 0); 
	bool result; 
	bool expected; 
	expected = true; 
	result = system.AddCar(1); 
	Assert.Equal(expected, result); 
	result = system.AddCar(2); 
	Assert.Equal(expected, result);

	expected = false;
	result = system.AddCar(3);
	Assert.Equal(expected, result);
	result = system.AddCar(1);
	Assert.Equal(expected, result);
}
/*
Input
["ParkingSystem", "addCar", "addCar", "addCar", "addCar"]
[[1, 1, 0], [1], [2], [3], [1]]
Output
[null, true, true, false, false]

Explanation
ParkingSystem parkingSystem = new ParkingSystem(1, 1, 0);
parkingSystem.addCar(1); // return true because there is 1 available slot for a big car
parkingSystem.addCar(2); // return true because there is 1 available slot for a medium car
parkingSystem.addCar(3); // return false because there is no available slot for a small car
parkingSystem.addCar(1); // return false because there is no available slot for a big car. It is already occupied.
*/
#endregion