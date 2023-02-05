namespace LeetCode.Solutions.P00740_DeleteAndEarn;

public class Solution
{
    private Dictionary<int, int> _numValues;
    private Dictionary<int, int> _maxPoints;

    public Solution()
    {
        _numValues = new Dictionary<int, int>();
        _maxPoints = new Dictionary<int, int>();
    }

    public int DeleteAndEarn(int[] nums)
    {
        int maxValue = int.MinValue;

        foreach (int num in nums)
        {
            if (num > maxValue) maxValue = num;

            if (!_numValues.ContainsKey(num))
            {
                _numValues.Add(num, 0);
            }
            _numValues[num] += num;
        }

        if (_numValues.Keys.Count == 1)
        {
            return _numValues[maxValue];
        }

        return MaxPoints(maxValue);
    }

    private int MaxPoints(int value)
    {
        if (value == 0) return 0;
        if (value == 1)
        {
            return _numValues.ContainsKey(1) ? _numValues[1] : 0;
        }

        if (_maxPoints.ContainsKey(value))
        {
            return _maxPoints[value];
        }
        else
        {
            int currentValue = _numValues.ContainsKey(value) ? _numValues[value] : 0;
            int maxPoints = Math.Max(MaxPoints(value - 2) + currentValue, MaxPoints(value - 1));
            _maxPoints.Add(value, maxPoints);
            return maxPoints;
        }

    }
}
