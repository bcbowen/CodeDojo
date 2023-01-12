namespace LeetCode.Solutions.P00303_RangeSumQueryImmutable;

public class NumArray
{
    private int[] _nums;
    private int[] _sums;

    public NumArray(int[] nums)
    {
        _nums = nums;
        _sums = new int[_nums.Length];
        int total = 0;
        for (int i = 0; i < _nums.Length; i++)
        {
            total += _nums[i];
            _sums[i] = total;
        }
    }

    public int SumRange_1(int left, int right)
    {
        int sum = 0;
        for (int i = left; i <= right; i++)
        {
            sum += _nums[i];
        }
        return sum;
    }

    public int SumRange(int left, int right)
    {
        int result = _sums[right] - (left > 0 ? _sums[left - 1] : 0);
        return result;
    }
}

