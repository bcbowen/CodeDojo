namespace LeetCode.Solutions.Medium.P00556_NextGreaterElementIII;


public class Solution
{
    public int NextGreaterElement(int n)
    {
        if (n < 10)
        {
            return -1;
        }

        if (n < 100)
        {
            int swapped = SwapDigits(n);
            return swapped > n ? swapped : -1;
        }

        return GetNext(n);
    }

    internal int GetNext(int n)
    {
        int[] digits = GetDigits(n);

        for (int i = digits.Length - 1; i > 0; i--)
        {
            if (digits[i] > digits[i - 1])
            {
                int index = i;
                int value = digits[i];
                for (int j = i; j < digits.Length; j++)
                {
                    if (digits[j] < value && digits[j] > digits[i - 1])
                    {
                        index = j;
                        value = digits[j];
                    }
                }

                int temp = digits[i - 1];
                digits[i - 1] = digits[index];
                digits[index] = temp;
                Array.Sort(digits, i, digits.Length - i);
                return GetValue(digits);
            }

        }

        return -1;
    }

    internal int SwapDigits(int n)
    {
        int[] digits = GetDigits(n);

        return digits[1] * 10 + digits[0];
    }

    internal int GetValue(int[] digits)
    {
        long value = 0;
        long place = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            value += digits[i] * place;
            place *= 10;
        }
        return value <= int.MaxValue ? (int)value : -1;
    }

    internal int[] GetDigits(int n)
    {
        List<int> digits = new List<int>();

        while (n > 0)
        {
            int digit = n % 10;
            digits.Insert(0, digit);
            n /= 10;
        }
        return digits.ToArray();
    }
}

