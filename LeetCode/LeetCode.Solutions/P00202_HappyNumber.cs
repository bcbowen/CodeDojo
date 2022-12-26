namespace LeetCode.Solutions.P00202_HappyNumber;

public class Solution
{
    public bool IsHappy(int n)
    {
        int sumDigits = GetSumDigits(n);
        HashSet<int> seen = new HashSet<int>();
        while (sumDigits != 1)
        {
            if (seen.Contains(sumDigits)) break;
            seen.Add(sumDigits);
            sumDigits = GetSumDigits(sumDigits);
        }

        return sumDigits == 1;
    }

    private int GetSumDigits(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += (int)Math.Pow(n % 10, 2);
            n /= 10;
        }

        return sum;
    }
}