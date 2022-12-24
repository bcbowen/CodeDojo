namespace LeetCode.Solutions.P00065_Sqrt;

public class Solution
{
    internal int SearchRoot(long min, long max, long x)
    {
        if (min == max) return (int)min;
        if (max - min == 1)
        {
            if (max * max > x) return (int)min;
            return (int)max;
        }

        long mid = min + (max - min) / 2;

        long square = mid * mid;
        if (square == x) return (int)mid;

        if (square < x) return SearchRoot(mid, max, x);
        return SearchRoot(min, mid, x);
    }

    public int MySqrt(long x)
    {
        switch (x)
        {
            case 0:
            case 1:
                return (int)x;
            case 2:
            case 3:
                return 1;
        }

        int max = x > int.MaxValue ? int.MaxValue : (int)x;
        return SearchRoot(2, max, x);

    }
}