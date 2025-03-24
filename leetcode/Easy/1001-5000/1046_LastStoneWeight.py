import pytest
import heapq

from dataclasses import dataclass
from typing import List

class Solution:

    def lastStoneWeight(self, stones: List[int]) -> int:
        stones = [-stone for stone in stones]
        heapq.heapify(stones)

        while len(stones) > 1: 
            s1 = heapq.heappop(stones)
            s2 = heapq.heappop(stones)
            if s2 > s1: 
                heapq.heappush(stones, -(s2 - s1))
        if stones: 
            return -stones[0] 
        
        return 0


"""
Example 1:
Input: stones = [2,7,4,1,8,1]
Output: 1
Explanation: 
We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of the last stone.

Example 2:
Input: stones = [1]
Output: 1
"""
@pytest.mark.parametrize("stones, expected", [
    ([2,7,4,1,8,1], 1), 
    ([1], 1)
])
def test_lastStoneWeight(stones: List[int], expected: int):
    result = Solution().lastStoneWeight(stones)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])