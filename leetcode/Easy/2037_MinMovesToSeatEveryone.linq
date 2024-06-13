<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}



public int MinMovesToSeat(int[] seats, int[] students)
{
	int result = 0; 
	Array.Sort(seats);
	Array.Sort(students);
	for(int i = 0; i < seats.Length; i++) 
	{
		result += Math.Abs(seats[i] - students[i]); 
	}
	
	return result; 
}

/*

Input: seats = [3,1,5], students = [2,7,4]
Output: 4

Input: seats = [4,1,5,9], students = [1,3,2,6]
Output: 7

Input: seats = [2,2,6,6], students = [1,3,2,6]
Output: 4

*/

[Theory]
[InlineData(new[] { 3, 1, 5 }, new[] { 2, 7, 4 }, 4)]
[InlineData(new[] { 4, 1, 5, 9 }, new[] { 1, 3, 2, 6 }, 7)]
[InlineData(new[] { 2, 2, 6, 6 }, new[] { 1, 3, 2, 6 }, 4)]
void Test(int[] seats, int[] students, int expected)
{
	int result = MinMovesToSeat(seats, students);
	Assert.Equal(expected, result);

}
