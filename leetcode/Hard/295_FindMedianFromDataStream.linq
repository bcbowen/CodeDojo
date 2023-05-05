<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class MedianFinder
{
	PriorityQueue<int, int> firstHalf = new PriorityQueue<int, int>();
	PriorityQueue<int, int> secondHalf = new PriorityQueue<int, int>();
	private int _round;

	public MedianFinder()
	{
		_round = 0;
	}

	public void AddNum(int num)
	{
		if (firstHalf.Count == 0 && secondHalf.Count == 0) 
		{
			firstHalf.Enqueue(num, -num);
		}
		else if (firstHalf.Count > 0 && firstHalf.Peek() > num)
		{
			firstHalf.Enqueue(num, -num);
		}
		else
		{
			secondHalf.Enqueue(num, num);
		}

		_round++;

		// rebalance the queues... equal for even rounds, off by one for odd rounds
		int transfer;
		if (_round % 2 == 0)
		{
			while (firstHalf.Count > secondHalf.Count)
			{
				transfer = firstHalf.Dequeue();
				secondHalf.Enqueue(transfer, transfer);
			}
			while (secondHalf.Count > firstHalf.Count)
			{
				transfer = secondHalf.Dequeue();
				firstHalf.Enqueue(transfer, -transfer);
			}
		}
		else
		{
			while (firstHalf.Count - secondHalf.Count > 1)
			{
				transfer = firstHalf.Dequeue();
				secondHalf.Enqueue(transfer, transfer);
			}

			while (secondHalf.Count - firstHalf.Count > 1)
			{
				transfer = secondHalf.Dequeue();
				firstHalf.Enqueue(transfer, -transfer);
			}
		}
	}

	public double FindMedian()
	{
		if (_round % 2 == 0)
		{
			return ((double)firstHalf.Peek() + secondHalf.Peek()) / 2;
		}
		else
		{
			return firstHalf.Count > secondHalf.Count ? firstHalf.Peek() : secondHalf.Peek();
		}
	}
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

[Theory]
[InlineData(new[] { 2, 3, 4 }, 3.0)]
[InlineData(new[] { 2, 3 }, 2.5)]
[InlineData(new[] { 1, 2 }, 1.5)]
[InlineData(new[] { 1, 2, 3 }, 2.0)]
void SimpleTests(int[] values, double expected)
{
	MedianFinder m = new MedianFinder();
	foreach (int value in values)
	{
		m.AddNum(value);
	}
	Assert.Equal(expected, m.FindMedian());
}

/*
The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value and the median is the mean of the two middle values.

For example, for arr = [2,3,4], the median is 3.
For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
Implement the MedianFinder class:

MedianFinder() initializes the MedianFinder object.
void addNum(int num) adds the integer num from the data stream to the data structure.
double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.
 

Example 1:

Input
["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
[[], [1], [2], [], [3], []]
Output
[null, null, null, 1.5, null, 2.0]

Explanation
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.addNum(2);    // arr = [1, 2]
medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
medianFinder.addNum(3);    // arr[1, 2, 3]
medianFinder.findMedian(); // return 2.0
*/