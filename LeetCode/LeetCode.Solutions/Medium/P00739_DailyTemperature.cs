namespace LeetCode.Solutions.P00739_DailyTemperature;

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        Stack<(int, int)> tempStack = new Stack<(int, int)>();
        int[] answers = new int[temperatures.Length];

        tempStack.Push((0, temperatures[0]));
        for (int i = 1; i < temperatures.Length; i++)
        {
            int index = 0;
            int temp = 0;
            if (tempStack.Count > 0) (index, temp) = tempStack.Peek();

            while (temperatures[i] > temp)
            {
                (index, temp) = tempStack.Pop();
                answers[index] = i - index;
                if (tempStack.Count == 0) break;
                (index, temp) = tempStack.Peek();
            }
            tempStack.Push((i, temperatures[i]));
        }
        return answers;
    }
}
