namespace LeetCode.Solutions.P01356_SortIntsByCountOf1Bits;

public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        SortedList<int, List<int>> numbersByBitCount = new SortedList<int, List<int>>();

        foreach (int i in arr)
        {
            int bitCount = GetBitCount(i);
            if (!numbersByBitCount.ContainsKey(bitCount))
            {
                numbersByBitCount.Add(bitCount, new List<int>());
            }

            numbersByBitCount[bitCount].Add(i);

        }
        List<int> result = new List<int>();


        foreach (int key in numbersByBitCount.Keys)
        {
            numbersByBitCount[key].Sort();
            result.AddRange(numbersByBitCount[key]);
        }

        return result.ToArray();
    }

    internal int GetBitCount(int value)
    {
        int result = 0;
        while (value > 0)
        {
            if ((value & 1) == 1) result++;
            value >>= 1;
        }
        return result;
    }
}
