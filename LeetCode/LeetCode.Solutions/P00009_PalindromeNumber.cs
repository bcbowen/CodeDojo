namespace LeetCode.Solutions.P00009_PalindromeNumber
{
    
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;
            int[] digits = GetDigits(x);
            int l = 0;
            int r = digits.Length - 1;
            while (l < r)
            {
                if (digits[l++] != digits[r--]) return false;
            }
            return true;
        }

        private int[] GetDigits(int i)
        {
            List<int> digits = new List<int>();
            while (i > 0)
            {
                digits.Insert(0, i % 10);
                i /= 10;
            }

            return digits.ToArray();
        }
    }
}