using System.Numerics;
using System.Text.RegularExpressions;
using System.Text;

namespace LeetCode.Solutions.P00050_Pow_X_N;

public class Solution
{
    public double MyPow(double x, int n)
    {
        if (x == 1) return x;
        if (x == -1) return (n % 2) == 0 ? 1 : -1;

        long exponent = n;
        if (Math.Abs(exponent) > 10000)
        {
            if (Math.Abs(x) < .01 || exponent < 0) return 0;
            if (x >= 1.01) return double.PositiveInfinity;
            if (x <= -1.01) return (n % 2) == 0 ? double.NegativeInfinity : double.PositiveInfinity;

        }

        double val = exponent >= 0 ? x : 1 / x;
        double result = 1;
        for (int i = 1; i <= Math.Abs(exponent); i++)
        {
            result *= val;
        }

        return result;
    }
}