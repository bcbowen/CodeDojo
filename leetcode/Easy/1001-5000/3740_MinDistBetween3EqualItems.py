import pytest

#from collections import defaultdict
from typing import List, Tuple



class Solution:
    def minimumDistance(self, nums: List[int]) -> int:
        counts = {}
        min_dist = 1001
        for i in range(len(nums)):
            if not nums[i] in counts: 
                counts[nums[i]] = [] 
            counts[nums[i]].append(i)
        for key, indices in counts.items(): 
            if len(indices) > 2: 
                dist = self.find_min_dist(indices)
                min_dist = min(dist, min_dist) 
        if min_dist == 1001: 
            min_dist = -1
        return min_dist
    
    def find_dist(self, values: Tuple[int, int, int]) -> int:
        # abs(i - j) + abs(j - k) + abs(k - i)
        i, j, k = values
        return abs(i - j) + abs(j - k) + abs(k - i)

    def find_min_dist(self, indices : List[int]) -> int: 
        min_dist = 1001
        triplets = self.find_triplets(indices)
        for i, j, k in triplets: 
            dist = self.find_dist((i, j, k))
            min_dist = min(dist, min_dist)
        return min_dist
    
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
The minimum distance is achieved by the good tuple (0, 2, 3).

(0, 2, 3) is a good tuple because nums[0] == nums[2] == nums[3] == 1. Its distance is abs(0 - 2) + abs(2 - 3) + abs(3 - 0) = 2 + 1 + 3 = 6.

Example 2:

Input: nums = [1,1,2,3,2,1,2]

Output: 8

Explanation:

The minimum distance is achieved by the good tuple (2, 4, 6).
"""
@pytest.mark.parametrize("", [
    (0, 2, 3, 6), 
    (2, 4, 6, 8)
])
def find_dist_test(i: int, j: int, k: int, expected: int):
    result = Solution().find_dist((i, j, k))
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

TC 826
[1,2,1,1,2,2] Expected: 6


"""
@pytest.mark.parametrize("nums, expected", [
    ([1,2,1,1,3], 6),
    ([1,1,2,3,2,1,2], 8), 
    ([1], -1), 
    ([1,2,1,1,2,2], 6)
])
def test_minDist(nums: List[int], expected: int): 
    result = Solution().minimumDistance(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 