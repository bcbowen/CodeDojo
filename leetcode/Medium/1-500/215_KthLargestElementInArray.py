import heapq
import pytest

from typing import List

class Solution:
    def findKthLargest(self, nums: List[int], k: int) -> int:
        max_heap = [-num for num in nums] 
        heapq.heapify(max_heap)
        val = -1
        for _ in range(k): 
            val = heapq.heappop(max_heap)
        return -val


"""
Example 1:
Input: nums = [3,2,1,5,6,4], k = 2
Output: 5

Example 2:
Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([3,2,1,5,6,4], 2, 5), 
    ([3,2,3,1,2,4,5,5,6], 4, 4)
])
def test_findKthLargest(nums: List[int], k: int, expected: int):
    result = Solution().findKthLargest(nums, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])