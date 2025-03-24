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
	public int OpenLock(string[] deadends, string target)
	{
		HashSet<string> deadSet = new HashSet<string>();
		foreach (string deadEnd in deadends)
		{
			deadSet.Add(deadEnd);
		}

		Queue<string> queue = new Queue<string>();
		queue.Enqueue("0000");
		queue.Enqueue(null);
		HashSet<string> seenSet = new HashSet<string>();
		seenSet.Add("0000");
		int depth = 0;
		while (queue.Count > 0)
		{
			string node = queue.Dequeue();
			if (node == null)
			{
				depth++;
				if (queue.Count > 0 && queue.Peek() != null)
				{
					queue.Enqueue(null);
				}
			}
			else if (node == target)
			{
				return depth;
			}
			else if (!deadSet.Contains(node))
			{
				for (int i = 0; i < 4; ++i)
				{
					for (int d = -1; d <= 1; d += 2)
					{
						int y = ((node[i] - '0') + d + 10) % 10;
						string nei = node.Substring(0, i) + ("" + y) + node.Substring(i + 1);
						if (!seenSet.Contains(nei))
						{
							seenSet.Add(nei);
							queue.Enqueue(nei);
						}
					}
				}
			}

		}

		return -1;
	}

}

[Theory]
[InlineData(new[] { "0201", "0101", "0102", "1212", "2002" }, "0202", 6)]
[InlineData(new[] { "8888" }, "0009", 1)]
[InlineData(new[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" }, "8888", -1)]

public void OpenTheLockTest(string[] deadEnds, string target, int expected)
{
	int result = new Solution().OpenLock(deadEnds, target);
	Assert.Equal(expected, result);
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