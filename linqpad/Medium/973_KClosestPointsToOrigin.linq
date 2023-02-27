<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public int[][] KClosest(int[][] points, int k)
	{
		int[] origin = new int[] {0, 0}; 
		PriorityQueue<int[], double> distanceQueue = new PriorityQueue<int[], double>();
		foreach(int[] point in points)
		{
			double distance = CalcDistance(origin, point);
			distanceQueue.Enqueue(point, distance);
		}
		int[][] closestPoints = new int[k][];
		for (int i  = 0; i < k; i++) 
		{
			closestPoints[i] = distanceQueue.Dequeue();
		}
		return closestPoints;
	}

	internal static double CalcDistance(int[] p1, int[] p2) 
	{
		// The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).
		double[] dp1 = new[] {(double)p1[0], (double)p1[1]};
		double[] dp2 = new[] {(double)p2[0], (double)p2[1]};
		double distance = Math.Sqrt(Math.Pow((dp1[0] - dp2[0]), 2) + Math.Pow((dp1[1] - dp2[1]), 2));
		return distance;
	}
	
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);


[Fact]
void TestKClosest1()
{
	/*
	Input: points = [[1,3],[-2,2]], k = 1
	Output: [[-2,2]]
	Explanation:
	The distance between (1, 3) and the origin is sqrt(10).
	The distance between (-2, 2) and the origin is sqrt(8).
	Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
	We only want the closest k = 1 points from the origin, so the answer is just [[-2,2]].
	*/
	int[][] expected = new[]
	{
		new []{-2, 2}
	};

	int k = 1;
	int[][] points = new[] { new[] { 1, 3 }, new[] { -2, 2 } };
	
	int[][] result = new Solution().KClosest(points, k);
	Assert.Equal(expected, result);
}

[Fact]
void TestKClosest2()
{
	/*
	Example 2:
	Input: points = [[3,3],[5,-1],[-2,4]], k = 2
	Output: [[3,3],[-2,4]]
	Explanation: The answer [[-2,4],[3,3]] would also be accepted.
	*/
	int[][] expected = new[]
    {
		new []{3, 3},
		new []{-2, 4}
	};

	int k = 2;
	int[][] points = new[] { new[] { 3, 3 }, new[] { 5, -1 }, new[] { -2, 4 } };

	int[][] result = new Solution().KClosest(points, k);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(new[] {1, 3}, 10)]
[InlineData(new[] {-2, 2}, 8)]
void TestCalc(int[] point, int expectedSquared)
{
	double expected = Math.Sqrt((double)expectedSquared);
	int[] origin = new int[] {0, 0};
	double result = Solution.CalcDistance(origin, point);
	Assert.Equal(expected, result);
}

/*

Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest 
points to the origin (0, 0).



You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).




*/
#endregion