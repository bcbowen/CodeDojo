<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public bool IsNStraightHand(int[] hand, int groupSize)
{
	if (hand.Length < groupSize || hand.Length % groupSize != 0) return false;
	
	Array.Sort(hand);
	int groupCount = hand.Length / groupSize;
	Stack<int>[] groups = new Stack<int>[groupCount];
	for(int i = 0; i < groups.Length; i++) 
	{
		groups[i] = new Stack<int>();
	}
	foreach(int card in hand)
	{
		bool pushed = false;
		foreach(Stack<int> group in groups)
		{
			if (group.Count < groupSize && (group.Count == 0 || group.Peek() == card - 1)) 
			{
				group.Push(card); 
				pushed = true;
				break; 
			}
		}
		if(!pushed) return false;
	}
	return true;
}

/*

Input: hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
Output: true

Input: hand = [1,2,3,4,5], groupSize = 4
Output: false

*/

[Theory]
[InlineData(new[] {2,1}, 2, true)]
[InlineData(new[] {1,2,3,1,2,3,1,2,3}, 3, true)]
[InlineData(new[] {9,2,3,6,5,1,4,7,8}, 3, true)]
[InlineData(new[] {1,2,3,2,3,4,1,2,3}, 3, true)]
[InlineData(new[] {1,2,3,9,7,8,6,4,5}, 3, true)]
[InlineData(new[] {1,2,3,6,2,3,4,7,8}, 3, true)]
[InlineData(new[] {1,2,3,6,2,3,4,7,9}, 3, false)]
[InlineData(new[] {1,2,3,4,5}, 4, false)]
void Test(int[] hand, int groupSize, bool expected) 
{
	bool result = IsNStraightHand(hand, groupSize); 
	Assert.Equal(expected, result); 
	
}

[Fact]
void Test61() 
{
	int[] hand = {2, 1};
	bool result = IsNStraightHand(hand, 2); 
	bool expected = true;
	Assert.Equal(expected, result); 
}

