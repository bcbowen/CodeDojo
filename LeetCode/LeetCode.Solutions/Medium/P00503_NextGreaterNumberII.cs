namespace LeetCode.Solutions.Medium;

public class Solution
{
    public int[] NextGreaterElements(int[] nums)
    {
        int[] answers = new int[nums.Length];
        Stack<int> monoDecreasingStack = new Stack<int>();
        for (int i = 0; i < 2; i++)
        {
            for (int j = nums.Length - 1; j >= 0; j--)
            {
                while (monoDecreasingStack.Count > 0 && nums[monoDecreasingStack.Peek()] <= nums[j])
                {
                    monoDecreasingStack.Pop();
                }

                answers[j] = monoDecreasingStack.Count > 0 ? nums[monoDecreasingStack.Peek()] : -1;

                monoDecreasingStack.Push(j);
            }
        }
        return answers;
    }
}