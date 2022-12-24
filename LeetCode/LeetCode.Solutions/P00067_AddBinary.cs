using System.Numerics;
using System.Text.RegularExpressions;
using System.Text;

namespace LeetCode.Solutions.P00067_AddBinary;

public class Solution
{
    public string AddBinary(string a, string b)
    {
        StringBuilder result = new StringBuilder();
        int aIndex = a.Length - 1;
        int bIndex = b.Length - 1;
        bool carry = false;
        while (aIndex > -1 || bIndex > -1)
        {
            int aVal = aIndex > -1 ? int.Parse(a[aIndex].ToString()) : 0;
            int bVal = bIndex > -1 ? int.Parse(b[bIndex].ToString()) : 0;
            int cVal = aVal + bVal;
            if (carry)
            {
                switch (cVal)
                {
                    case 0:
                        carry = false;
                        cVal = 1;
                        break;
                    case 1:
                        cVal = 0;
                        carry = true;
                        break;
                    case 2:
                        cVal = 1;
                        carry = true;
                        break;
                }
            }
            else
            {
                if (cVal == 2)
                {
                    cVal = 0;
                    carry = true;
                }
            }
            aIndex--;
            bIndex--;
            result.Insert(0, cVal);
        }
        if (carry)
        {
            result.Insert(0, 1);
        }
        return result.ToString();
    }
}