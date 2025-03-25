import heapq
import pytest
from collections import defaultdict
from typing import List


class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        counts = defaultdict(int)
        for num in nums: 
            counts[num] += 1
        
        heap = [] 
        for key in counts.keys(): 
            heapq.heappush(heap, (-counts[key], key))

        result = [] 
        for _ in range(k): 
            result.append(heapq.heappop(heap)[1])
        
        return result


"""
Example 1:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]

Example 2:
Input: nums = [1], k = 1
Output: [1]
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([1,1,1,2,2,3], 2, [1,2]), 
    ([1], 1, [1])
])
def test_topKFrequent(nums: List[int], k: int, expected: List[int]):
    result = Solution().topKFrequent(nums, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 