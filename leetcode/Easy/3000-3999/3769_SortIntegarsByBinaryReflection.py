import pytest

from typing import List

class Solution:
    def sortByReflection(self, nums: List[int]) -> List[int]:
        reflections = [(num, int(bin(num)[2:][::-1].lstrip('0'), 2)) for num in nums]
        reflections.sort(key=lambda x: (x[1], x[0]))
        return [r[0] for r in reflections]
    

"""

Example 1:
Input: nums = [4,5,4]

Output: [4,4,5]

Explanation:

Binary reflections are:

4 -> (binary) 100 -> (reversed) 001 -> 1
5 -> (binary) 101 -> (reversed) 101 -> 5
4 -> (binary) 100 -> (reversed) 001 -> 1
Sorting by the reflected values gives [4, 4, 5].

Example 2:
Input: nums = [3,6,5,8]

Output: [8,3,6,5]

Explanation:

Binary reflections are:

3 -> (binary) 11 -> (reversed) 11 -> 3
6 -> (binary) 110 -> (reversed) 011 -> 3
5 -> (binary) 101 -> (reversed) 101 -> 5
8 -> (binary) 1000 -> (reversed) 0001 -> 1
Sorting by the reflected values gives [8, 3, 6, 5].
Note that 3 and 6 have the same reflection, so we arrange them in increasing order of original value.

TC 889
nums = [8,2]
Expected
[2,8]

"""
@pytest.mark.parametrize("nums, expected", [
    ([4,5,4], [4, 4, 5]), 
    ([3,6,5,8], [8,3,6,5]), 
    ([8, 2], [2, 8])
])
def test_sortByReflection(nums: List[int], expected: List[int]):
    result = Solution().sortByReflection(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])