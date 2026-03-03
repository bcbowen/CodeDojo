#from collections import deque
from typing import List 

import pytest

class Solution:
    def findBuildings(self, heights: List[int]) -> List[int]:
        queue = []

        for i in range(len(heights)): 
            while queue and heights[i] >= heights[queue[-1]]: 
                queue.pop()
            queue.append(i)
        return queue

"""
Example 1:
Input: heights = [4,2,3,1]
Output: [0,2,3]
Explanation: Building 1 (0-indexed) does not have an ocean view because building 2 is taller.

Example 2:
Input: heights = [4,3,2,1]
Output: [0,1,2,3]
Explanation: All the buildings have an ocean view.

Example 3:
Input: heights = [1,3,2,4]
Output: [3]
Explanation: Only building 3 has an ocean view.
"""
@pytest.mark.parametrize("heights, expected", [
    ([4,2,3,1], [0,2,3]), 
    ([4,3,2,1], [0,1,2,3]), 
    ([1,3,2,4], [3])
])
def test_findBuildings(heights: List[int], expected: List[int]):
    result = Solution().findBuildings(heights)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])  