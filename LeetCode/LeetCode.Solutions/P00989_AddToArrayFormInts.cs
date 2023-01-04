namespace LeetCode.Solutions.P00989_AddToArrayFormInts;

public class Solution
{
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        // count digits in k
        int n = 0;
        int k2 = k;
        while (k2 > 0)
        {
            k2 /= 10;
            n++;
        }

        List<int> result = new List<int>();

        int i;
        // start with zeros for result, with one extra in case we carry
        for (i = 0; i < Math.Max(num.Length, n) + 1; i++)
        {
            result.Add(0);
        }

        bool carry = false;

        int val;
        int sum;
        i = num.Length - 1;
        int j = result.Count - 1;
        while (k > 0 || i >= 0)
        {
            val = k % 10;
            sum = (i >= 0 ? num[i] : 0) + val + (carry ? 1 : 0);
            carry = sum > 9;
            result[j] = sum % 10;
            i--;
            j--;
            k /= 10;

        }
        if (carry)
        {
            result[j] = 1;
            carry = false;
        }

        if (result[0] == 0) result.RemoveAt(0);
        return result;
    }
}
