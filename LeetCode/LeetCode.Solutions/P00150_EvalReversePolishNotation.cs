namespace LeetCode.Solutions.P00150_EvalReversePolishNotation;

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> values = new Stack<int>();
        int value1;
        int value2;
        foreach (string token in tokens)
        {
            switch (token)
            {
                case "+":
                    value1 = values.Pop();
                    value2 = values.Pop();
                    values.Push(value1 + value2);
                    break;
                case "-":
                    value1 = values.Pop();
                    value2 = values.Pop();
                    values.Push(value2 - value1);
                    break;
                case "*":
                    value1 = values.Pop();
                    value2 = values.Pop();
                    values.Push(value1 * value2);
                    break;
                case "/":
                    value1 = values.Pop();
                    value2 = values.Pop();
                    values.Push(value2 / value1);
                    break;
                default:
                    if (int.TryParse(token, out value1))
                    {
                        values.Push(value1);
                    }
                    break;
            }

        }

        return values.Pop();
    }

}