using System.Text;

namespace LeetCode.Solutions.Easy.P01678_GoalParserImplementation;

public class Solution
{
    public string Interpret(string command)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < command.Length; i++)
        {
            switch (command[i])
            {
                case 'G':
                    result.Append(command[i]);
                    break;
                case ')':
                    result.Append(command[i - 1] == '(' ? "o" : "al");
                    break;
            }
        }
        return result.ToString();
    }
}