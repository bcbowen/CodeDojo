namespace LeetCode.Solutions.Easy.P01281_SubtractProductAndSumOfDigitsOfInt;

public class Solution
{
    public int SubtractProductAndSum(int n)
    {
        int sum = SumDigits(n);
        int product = ProductDigits(n);
        return product - sum;
    }

    int SumDigits(int val)
    {
        int[] digits = GetDigits(val);
        return digits.Sum(d => d);
    }

    int ProductDigits(int val)
    {
        int[] digits = GetDigits(val);
        int product = 1;
        foreach (int digit in digits)
        {
            product *= digit;
        }
        return product;
    }

    int[] GetDigits(int val)
    {
        List<int> digits = new List<int>();
        while (val > 0)
        {
            digits.Add(val % 10);
            val /= 10;
        }
        digits.Reverse();
        return digits.ToArray();
    }

}
