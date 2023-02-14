using LeetCode.Solutions.Medium.P00752_OpenTheLock;

namespace LeetCode.Tests.Medium.P00752_OpenTheLock;

[TestFixture]
[Category("Medium")]
public class OpenLockTests
{
    [TestCase(new[] { "0201", "0101", "0102", "1212", "2002" }, "0202", 6)]
    [TestCase(new[] { "8888" }, "0009", 1)]
    [TestCase(new[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" }, "8888", -1)]

    public void OpenTheLockTest(string[] deadEnds, string target, int expected)
    {
        int result = new Solution().OpenLock(deadEnds, target);
        Assert.That(result, Is.EqualTo(expected));
    }
    /*
    Example 1:
    Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
    Output: 6
    Explanation: 
    A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
    Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
    because the wheels of the lock become stuck after the display becomes the dead end "0102".
    
    Example 2:
    Input: deadends = ["8888"], target = "0009"
    Output: 1
    Explanation: We can turn the last wheel in reverse to move from "0000" -> "0009".
    
    Example 3:
    Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
    Output: -1
    Explanation: We cannot reach the target without getting stuck.
    */

}