using LeetCode.Solutions.Medium.P00835_ImageOverlap;

namespace LeetCode.Tests.Medium.P00835_ImageOverlap;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void Test_Example1()
    {
        int[][] image1 = new int[3][];
        image1[0] = new[] { 1, 1, 0 };
        image1[1] = new[] { 0, 1, 0 };
        image1[2] = new[] { 0, 1, 0 };

        int[][] image2 = new int[3][];
        image2[0] = new[] { 0, 0, 0 };
        image2[1] = new[] { 0, 1, 1 };
        image2[2] = new[] { 0, 0, 1 };

        int expected = 3;
        int result = new Solution().LargestOverlap(image1, image2);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Example2()
    {
        int[][] image1 = new int[1][];
        image1[0] = new[] { 1 };

        int[][] image2 = new int[1][];
        image2[0] = new[] { 1 };

        int expected = 1;
        int result = new Solution().LargestOverlap(image1, image2);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Example3()
    {
        int[][] image1 = new int[1][];
        image1[0] = new[] { 0 };

        int[][] image2 = new int[1][];
        image2[0] = new[] { 0 };

        int expected = 0;
        int result = new Solution().LargestOverlap(image1, image2);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Example4()
    {
        int[][] image1 = new int[5][];
        image1[0] = new[] { 0, 0, 0, 0, 1 };
        image1[1] = new[] { 0, 0, 0, 0, 0 };
        image1[2] = new[] { 0, 0, 0, 0, 0 };
        image1[3] = new[] { 0, 0, 0, 0, 0 };
        image1[4] = new[] { 0, 0, 0, 0, 0 };

        int[][] image2 = new int[5][];
        image2[0] = new[] { 0, 0, 0, 0, 0 };
        image2[1] = new[] { 0, 0, 0, 0, 0 };
        image2[2] = new[] { 0, 0, 0, 0, 0 };
        image2[3] = new[] { 0, 0, 0, 0, 0 };
        image2[4] = new[] { 1, 0, 0, 0, 0 };

        int expected = 1;
        int result = new Solution().LargestOverlap(image1, image2);
        Assert.AreEqual(expected, result);
    }


}