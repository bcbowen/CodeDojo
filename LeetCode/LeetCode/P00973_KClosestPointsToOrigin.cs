using LeetCode.Solutions.P00973_KClosestPointsToOrigin;

namespace LeetCode.Tests.P00973_KClosestPointsToOrigin;

public class Tests
{
    [Test]
    public void TestKClosest1()
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
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestKClosest2()
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
        Assert.AreEqual(expected, result);
    }


    [TestCase(new[] { 1, 3 }, 10)]
    [TestCase(new[] { -2, 2 }, 8)]
    public void TestCalc(int[] point, int expectedSquared)
    {
        double expected = Math.Sqrt((double)expectedSquared);
        int[] origin = new int[] { 0, 0 };
        double result = Solution.CalcDistance(origin, point);
        Assert.AreEqual(expected, result);
    }


}