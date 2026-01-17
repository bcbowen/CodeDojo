import pytest

from collections import defaultdict
from typing import List



class Solution:
    def minimumDistance(self, nums: List[int]) -> int:
        counts = defaultdict(int)
        for i in range(len(nums)): 
            counts[nums[i]] += 1
    
    def find_min_dist(self, indexes : List[int]) -> int: 
        min_dist = float('inf')

    
    def find_triplets(self, values: List[int]) -> List[List[int]]: 
        if len(values) < 3: 
            return [[]]
        result = []
        for first in range(len(values) - 2): 
            for second in range(first + 1, len(values) - 1): 
                for third in range(second + 1, len(values)): 
                    result.append([values[first], values[second], values[third]])
        return result

@pytest.mark.parametrize("values, expected", [
    ([1, 2], [[]]), 
    ([1, 2, 3], [[1, 2, 3]]), 
    ([1, 2, 3, 4], [[1, 2, 3], [1, 2, 4], [1, 3, 4], [2, 3, 4]])
])
def test_find_triplets(values: List[int], expected: List[List[int]]):
    result = Solution().find_triplets(values)
    assert(result == expected)



"""
Example 1:
Input: nums = [1,2,1,1,3]
Output: 6
Explanation:
The minimum distance is achieved by the good tuple (0, 2, 3).
(0, 2, 3) is a good tuple because nums[0] == nums[2] == nums[3] == 1. Its distance is abs(0 - 2) + abs(2 - 3) + abs(3 - 0) = 2 + 1 + 3 = 6.

Example 2:
Input: nums = [1,1,2,3,2,1,2]
Output: 8
Explanation:
The minimum distance is achieved by the good tuple (2, 4, 6).
(2, 4, 6) is a good tuple because nums[2] == nums[4] == nums[6] == 2. Its distance is abs(2 - 4) + abs(4 - 6) + abs(6 - 2) = 2 + 2 + 4 = 8.

Example 3:
Input: nums = [1]
Output: -1
Explanation:
There are no good tuples. Therefore, the answer is -1.
"""
@pytest.mark.parametrize("nums, expected", [
    ([1,2,1,1,3], 6),
    ([1,1,2,3,2,1,2], 8), 
    ([1], -1) 
])
def test_minDist(nums: List[int], expected: int): 
    result = Solution().minimumDistance(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 