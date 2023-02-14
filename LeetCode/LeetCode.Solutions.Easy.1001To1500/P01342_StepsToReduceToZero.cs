namespace LeetCode.Solutions.Easy.P01342_StepsToReduceToZero;

public class Solution
{
    public int NumberOfSteps(int num)
    {
        int val = num;
        int steps = 0;
        while (val > 0)
        {
            if (val % 2 == 0)
            {
                val /= 2;
            }
            else
            {
                val -= 1;
            }
            steps++;
        }

        return steps;
    }
}