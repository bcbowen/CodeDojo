# 2341_MaxPairsInArray.py

import pytest

class Solution:
    def number_of_pairs(self, nums):
        result = [0, 0]
        value_counts = {}
        
        for num in nums:
            if num in value_counts:
                value_counts[num] += 1
            else:
                value_counts[num] = 1
        
        singles = 0
        pairs = 0
        for key in value_counts.keys():
            singles += value_counts[key] % 2
            pairs += value_counts[key] // 2
        
        result[0] = pairs
        result[1] = singles
        return result

@pytest.mark.parametrize("nums, expected", [
    ([1, 3, 2, 1, 3, 2, 2], [3, 1]),
    ([1, 1], [1, 0]),
    ([0], [0, 1])
])
def test_number_of_pairs(nums, expected):
    result = Solution().number_of_pairs(nums)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])