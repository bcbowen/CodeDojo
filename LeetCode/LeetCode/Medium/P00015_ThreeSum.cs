using LeetCode.Solutions.Medium.P00015_ThreeSum;

namespace LeetCode.Tests.Medium.P00015_ThreeSum;

public class Tests
{
    [Test]
    [TestCase(new[] { -1, 0, 1, 2, -1, -4 }, new[] { -1, -1, 2 }, new[] { -1, 0, 1 })]
    [TestCase(new[] { 3, 0, -2, -1, 1, 2 }, new[] { -2, -1, 3 }, new[] { -2, 0, 2 }, new[] { -1, 0, 1 })]
    [TestCase(new[] { 0, 0, 0 }, new[] { 0, 0, 0 })]
    [TestCase(new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0 })]
    [TestCase(new[] { 1, -1, -1, 0 }, new[] { -1, 0, 1 })]
    public void Test(int[] nums, params int[][] expected)
    {
        IList<IList<int>> result = new Solution().ThreeSum(nums);
        List<List<int>> expectedList = new List<List<int>>();
        foreach (int[] intArray in expected)
        {
            Array.Sort(intArray);
            expectedList.Add(intArray.ToList());
        }

        HashSet<List<int>> sets = new HashSet<List<int>>();
        foreach (List<int> list in result)
        {
            list.Sort();
            Assert.That(sets.Contains(list), Is.False);
            Assert.That(Contains(expectedList, list), Is.True);
            sets.Add(list);
        }

        Assert.That(expected.Length, Is.EqualTo(sets.Count));
    }

    private bool Contains(List<List<int>> expected, List<int> result)
    {
        foreach (List<int> list in expected)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != result[i]) break;
                if (i == result.Count - 1) return true;
            }
        }

        return false;
    }
}