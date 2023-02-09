using LeetCode.Solutions.Medium.P00200_NumberIslands;

namespace LeetCode.Tests.Medium.P00200_NumberIslands;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(1,
        new char[] { '1', '1', '1', '1', '0' },
        new char[] { '1', '1', '0', '1', '0' },
        new char[] { '1', '1', '0', '0', '0' },
        new char[] { '0', '0', '0', '0', '0' }),]
    [TestCase(3,
        new char[] { '1', '1', '0', '0', '0' },
        new char[] { '1', '1', '0', '0', '0' },
        new char[] { '0', '0', '1', '0', '0' },
        new char[] { '0', '0', '0', '1', '1' }),]
    [TestCase(1,
        new char[] { '1' }),]
    [TestCase(1,
        new char[] { '1', '1', '1' },
        new char[] { '0', '1', '0' },
        new char[] { '1', '1', '1' }),]
    [TestCase(1,
        new char[] { '1', '0', '1', '1', '1' },
        new char[] { '1', '0', '1', '0', '1' },
        new char[] { '1', '1', '1', '0', '1' }),]

    // [["1","0","1","1","1"],["1","0","1","0","1"],["1","1","1","0","1"]]
    public void NumberIslandTest(int expected, params char[][] grid)
    {
        int result = new Solution().NumIslands(grid);
        Assert.That(result, Is.EqualTo(expected));
    }
    /*
    Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
    */

}