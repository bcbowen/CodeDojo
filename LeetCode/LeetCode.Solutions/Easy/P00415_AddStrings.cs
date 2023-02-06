using System.Text;

namespace LeetCode.Solutions.Easy.P00415_AddStrings;

public class Solution
{
    public string AddStrings(string x, string y)
    {
        int carry = 0;
        int top;
        int bottom;
        int sum;
        int n = Math.Max(x.Length, y.Length);
        x = x.PadLeft(n, '0');
        y = y.PadLeft(n, '0');
        if (x.Length == 1 || y.Length == 1)
        {
            return (int.Parse(x) + int.Parse(y)).ToString();
        }
        StringBuilder result = new StringBuilder();
        for (int i = x.Length - 1; i >= 0; i--)
        {
            top = int.Parse(x.Substring(i, 1));
            bottom = int.Parse(y.Substring(i, 1));
            sum = top + bottom + carry;
            if (sum > 9)
            {
                carry = 1;
                result.Insert(0, sum - 10);
            }
            else
            {
                carry = 0;
                result.Insert(0, sum);
            }
        }
        if (carry == 1)
        {
            result.Insert(0, carry);
        }
        return result.ToString().TrimStart('0');
    }
}