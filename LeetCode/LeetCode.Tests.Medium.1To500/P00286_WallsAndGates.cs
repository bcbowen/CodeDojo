using LeetCode.Solutions.Medium.P00286_WallsAndGates;

namespace LeetCode.Tests.Medium.P00286_WallsAndGates;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void Example1()
    {

        /*
        Example 1:
        Input: rooms = [[2147483647,-1,0,2147483647],[2147483647,2147483647,2147483647,-1],[2147483647,-1,2147483647,-1],[0,-1,2147483647,2147483647]]
        Output: [[3,-1,0,1],[2,2,1,-1],[1,-1,2,-1],[0,-1,3,4]]
        */
        int[][] rooms = new int[4][];
        rooms[0] = new[] { 2147483647, -1, 0, 2147483647 };
        rooms[1] = new[] { 2147483647, 2147483647, 2147483647, -1 };
        rooms[2] = new[] { 2147483647, -1, 2147483647, -1 };
        rooms[3] = new[] { 0, -1, 2147483647, 2147483647 };

        new Solution().WallsAndGates(rooms);
        int[][] expected = new int[4][];
        expected[0] = new[] { 3, -1, 0, 1 };
        expected[1] = new[] { 2, 2, 1, -1 };
        expected[2] = new[] { 1, -1, 2, -1 };
        expected[3] = new[] { 0, -1, 3, 4 };

        Assert.AreEqual(expected, rooms);
    }

    [Test]
    public void Example2()
    {

        /*
        Example 2:
        Input: rooms = [[-1]]
        Output: [[-1]]
        */
        int[][] rooms = new int[1][];
        rooms[0] = new[] { -1 };

        new Solution().WallsAndGates(rooms);
        int[][] expected = new int[1][];
        expected[0] = new[] { -1 };

        Assert.AreEqual(expected, rooms);
    }

    [Test]
    public void Example3()
    {

        /*
        Example 2:
        Input: rooms = [0]]
        Output: [[0]]
        */
        int[][] rooms = new int[1][];
        rooms[0] = new[] { 0 };

        new Solution().WallsAndGates(rooms);
        int[][] expected = new int[1][];
        expected[0] = new[] { 0 };

        Assert.AreEqual(expected, rooms);
    }

    [Test]
    public void Example4()
    {
        /*
        Input:
        [[2147483647,0,2147483647,2147483647,0,2147483647,-1,2147483647]]
        Output:
        [[1,0,1,1,0,2147483647,-1,2147483647]]
        Expected:
        [[1,0,1,1,0,1,-1,2147483647]]
        */

        int[][] rooms = new int[1][];
        rooms[0] = new[] { 2147483647, 0, 2147483647, 2147483647, 0, 2147483647, -1, 2147483647 };

        new Solution().WallsAndGates(rooms);
        int[][] expected = new int[1][];
        expected[0] = new[] { 1, 0, 1, 1, 0, 1, -1, 2147483647 };

        Assert.AreEqual(expected, rooms);

    }


}