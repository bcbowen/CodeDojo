<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class KthLargest
{
	PriorityQueue<int, int> _q;
	int _k;

	public KthLargest(int k, int[] nums)
	{
		_q = new PriorityQueue<int, int>();
		_k = k;
		foreach (int num in nums)
		{
			_q.Enqueue(num, num);
		}

		while (_q.Count > _k)
		{
			_q.Dequeue();
		}
	}

	public int Add(int val)
	{
		_q.Enqueue(val, val);
		while (_q.Count > _k)
		{
			_q.Dequeue(); 
		}
		return _q.Peek();
	}
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

[Theory]
[InlineData(3, new int[] { 4, 5, 8, 2 }, new int[] { 3, 5, 10, 9, 4 }, new int[] { 4, 5, 5, 8, 8 })]
[InlineData(1, new int[0], new int[] { -3, -2, -4, 0, 4 }, new int[] { -3, -2, -2, 0, 4 })]
void Tests(int k, int[] initValues, int[] adds, int[] expectedValues)
{
	List<int> results = new List<int>();
	//Node node = Node.Init(k, initValues);
	KthLargest driver = new KthLargest(k, initValues);
	foreach (int add in adds)
	{
		results.Add(driver.Add(add));
	}
	Assert.Equal(expectedValues, results);
}
/*
["KthLargest","add","add","add","add","add"]
[[1,[]],[-3],[-2],[-4],[0],[4]]

Example 1:

Input
["KthLargest", "add", "add", "add", "add", "add"]
[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
Output
[null, 4, 5, 5, 8, 8]

Explanation
KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
kthLargest.add(3);   // return 4
kthLargest.add(5);   // return 5
kthLargest.add(10);  // return 5
kthLargest.add(9);   // return 8
kthLargest.add(4);   // return 8
*/
